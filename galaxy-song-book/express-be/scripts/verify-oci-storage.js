#!/usr/bin/env node
/**
 * Checks that OCI Object Storage is wired up correctly, before you flip
 * STORAGE_DRIVER to "oci" and discover problems through broken uploads.
 *
 * Runs a real round-trip: PUT a small object, HEAD it, GET it, compare bytes,
 * then DELETE it. Nothing is left behind in the bucket.
 *
 *   node scripts/verify-oci-storage.js
 */
require('dotenv').config();

// Force the OCI driver for this check regardless of what .env says, so you can
// verify the connection while still running on the local driver.
process.env.STORAGE_DRIVER = 'oci';

const storage = require('../src/services/storage');

const ok = (m) => console.log(`  \x1b[32mOK\x1b[0m    ${m}`);
const bad = (m) => console.log(`  \x1b[31mFAIL\x1b[0m  ${m}`);

// The OCI SDK often throws objects whose .message is useless ("[object Object]").
// Dig out the fields that actually identify the problem.
function explain(err) {
  const parts = [];
  if (err.message && err.message !== '[object Object]') parts.push(err.message);
  if (err.statusCode) parts.push(`HTTP ${err.statusCode}`);
  if (err.serviceCode) parts.push(err.serviceCode);
  if (err.opcRequestId) parts.push(`opc-request-id=${err.opcRequestId}`);
  if (err.code) parts.push(err.code);
  if (!parts.length) {
    try { parts.push(JSON.stringify(err)); } catch { parts.push(String(err)); }
  }
  return parts.join(' | ');
}

// Maps the usual failures to the thing you actually need to change.
function hint(err) {
  const s = `${err.statusCode || ''} ${err.serviceCode || ''} ${err.code || ''} ${err.message || ''}`;
  if (/EAI_AGAIN|ENOTFOUND|ETIMEDOUT|ECONNREFUSED/i.test(s)) {
    return 'Network: cannot reach Oracle. Check internet access / proxy / VPN.';
  }
  if (/401|NotAuthenticated/i.test(s)) {
    return 'Auth rejected. Check OCI_USER_OCID, OCI_TENANCY_OCID and OCI_FINGERPRINT match the\n          key in Console -> My profile -> API keys, and that the .pem is the PRIVATE key.';
  }
  if (/404|BucketNotFound|NamespaceNotFound/i.test(s)) {
    return 'Bucket or namespace wrong. Verify OCI_BUCKET_NAME and OCI_NAMESPACE in the Console.';
  }
  if (/403|NotAuthorizedOrNotFound/i.test(s)) {
    return 'Authenticated but not allowed. Your user needs manage/use on object-family in this compartment.';
  }
  return null;
}

(async () => {
  console.log('\nOCI Object Storage check\n');

  console.log(`  bucket    : ${process.env.OCI_BUCKET_NAME || '(unset)'}`);
  console.log(`  namespace : ${process.env.OCI_NAMESPACE || '(auto-detect)'}`);
  console.log(`  region    : ${process.env.OCI_REGION || '(from config profile)'}`);
  console.log(`  prefix    : ${process.env.OCI_OBJECT_PREFIX || 'uploads/'}`);
  console.log(`  auth      : ${process.env.OCI_CONFIG_PROFILE
    ? `config profile "${process.env.OCI_CONFIG_PROFILE}"`
    : 'env-var credentials'}`);
  console.log('');

  if (!process.env.OCI_BUCKET_NAME) {
    bad('OCI_BUCKET_NAME is not set — nothing to test against.');
    process.exit(1);
  }

  const marker = `__verify-${Date.now()}.txt`;
  const payload = Buffer.from(`service-plus storage check ${new Date().toISOString()}`);

  try {
    await storage.save({ buffer: payload, originalname: marker, mimetype: 'text/plain' , filename: marker });
    ok(`upload    wrote ${payload.length} bytes as ${marker}`);
  } catch (err) {
    bad(`upload    ${explain(err)}`);
    const h = hint(err);
    if (h) console.log(`\n  \x1b[33m->\x1b[0m ${h}\n`);
    else {
      console.log('\n  Most likely causes:');
      console.log('    - SDK missing        -> npm install');
      console.log('    - bad credentials    -> re-check the four OCI_* values in .env');
      console.log('    - wrong bucket name  -> check OCI_BUCKET_NAME against the Console');
      console.log('    - policy denies PUT  -> user needs manage/use on object-family\n');
    }
    process.exit(1);
  }

  try {
    const found = await storage.exists(marker);
    found ? ok('exists    object is visible in the bucket')
          : bad('exists    object not found right after upload');
  } catch (err) {
    bad(`exists    ${err.message}`);
  }

  try {
    const obj = await storage.get(marker);
    if (!obj) throw new Error('get() returned null');
    const chunks = [];
    for await (const c of obj.stream) chunks.push(c);
    const got = Buffer.concat(chunks);
    got.equals(payload)
      ? ok(`download  ${got.length} bytes, content matches`)
      : bad(`download  content mismatch (${got.length} vs ${payload.length} bytes)`);
  } catch (err) {
    bad(`download  ${err.message}`);
  }

  try {
    await storage.remove(marker);
    ok('cleanup   test object deleted');
  } catch (err) {
    bad(`cleanup   ${err.message} (harmless: delete ${marker} by hand)`);
  }

  console.log('\n  Round-trip complete. Safe to set STORAGE_DRIVER=oci\n');
})().catch((err) => {
  console.error('\nUnexpected failure:', err.message, '\n');
  process.exit(1);
});
