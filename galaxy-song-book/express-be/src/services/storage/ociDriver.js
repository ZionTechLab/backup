const path = require('path');
const { Readable } = require('stream');

// OCI Object Storage driver.
//
// Credentials never reach the browser: the frontend talks to our Express API,
// and this module is the only thing holding OCI auth.
//
// Auth resolution order:
//   1. OCI_CONFIG_FILE / OCI_CONFIG_PROFILE  -> ~/.oci/config style file
//   2. OCI_TENANCY_OCID + OCI_USER_OCID + OCI_FINGERPRINT + OCI_PRIVATE_KEY
//      (or OCI_PRIVATE_KEY_PATH)             -> plain env vars, best for deploys
//
// The SDK packages are required lazily so the app still boots with
// STORAGE_DRIVER=local even when oci-* isn't installed.

let clientPromise = null;

function buildProvider(common) {
  const {
    OCI_CONFIG_FILE,
    OCI_CONFIG_PROFILE,
    OCI_TENANCY_OCID,
    OCI_USER_OCID,
    OCI_FINGERPRINT,
    OCI_PRIVATE_KEY,
    OCI_PRIVATE_KEY_PATH,
    OCI_PASSPHRASE,
    OCI_REGION,
  } = process.env;

  // 1. Config-file auth (typical on a dev machine after `oci setup config`).
  if (OCI_CONFIG_FILE || OCI_CONFIG_PROFILE) {
    return new common.ConfigFileAuthenticationDetailsProvider(
      OCI_CONFIG_FILE || undefined,
      OCI_CONFIG_PROFILE || 'DEFAULT'
    );
  }

  // 2. Env-var auth.
  if (OCI_TENANCY_OCID && OCI_USER_OCID && OCI_FINGERPRINT) {
    let privateKey = OCI_PRIVATE_KEY;
    if (!privateKey && OCI_PRIVATE_KEY_PATH) {
      privateKey = require('fs').readFileSync(OCI_PRIVATE_KEY_PATH, 'utf8');
    }
    if (!privateKey) {
      throw new Error('Set OCI_PRIVATE_KEY or OCI_PRIVATE_KEY_PATH for OCI storage');
    }
    // Allow \n-escaped keys, which is how most secret stores hand them back.
    privateKey = privateKey.replace(/\\n/g, '\n');

    if (!OCI_REGION) throw new Error('OCI_REGION is required for OCI storage');

    return new common.SimpleAuthenticationDetailsProvider(
      OCI_TENANCY_OCID,
      OCI_USER_OCID,
      OCI_FINGERPRINT,
      privateKey,
      OCI_PASSPHRASE || null,
      common.Region.fromRegionId(OCI_REGION)
    );
  }

  throw new Error(
    'OCI credentials missing. Set OCI_CONFIG_PROFILE, or OCI_TENANCY_OCID / OCI_USER_OCID / ' +
    'OCI_FINGERPRINT / OCI_PRIVATE_KEY(_PATH) / OCI_REGION.'
  );
}

// Lazily builds the client and resolves the namespace once, then reuses both.
async function getClient() {
  if (clientPromise) return clientPromise;

  clientPromise = (async () => {
    let common;
    let objectstorage;
    try {
      common = require('oci-common');
      objectstorage = require('oci-objectstorage');
    } catch (e) {
      throw new Error(
        'OCI SDK not installed. Run: npm install oci-common oci-objectstorage'
      );
    }

    const bucketName = process.env.OCI_BUCKET_NAME;
    if (!bucketName) throw new Error('OCI_BUCKET_NAME is required for OCI storage');

    const provider = buildProvider(common);
    const client = new objectstorage.ObjectStorageClient({
      authenticationDetailsProvider: provider,
    });

    // Namespace is fixed per tenancy; look it up unless pinned via env.
    let namespaceName = process.env.OCI_NAMESPACE;
    if (!namespaceName) {
      const res = await client.getNamespace({});
      namespaceName = res.value;
    }

    return { client, namespaceName, bucketName };
  })();

  // Don't cache a failed init — let the next request retry.
  clientPromise.catch(() => { clientPromise = null; });
  return clientPromise;
}

// Objects are namespaced under a prefix so the bucket can hold other things.
function objectName(name) {
  const prefix = (process.env.OCI_OBJECT_PREFIX || 'uploads/').replace(/^\/+/, '');
  return `${prefix}${name}`;
}

function assertSafeName(name) {
  if (!name || name.includes('..') || name.includes('/') || name.includes('\\')) {
    const err = new Error('Invalid file name');
    err.status = 400;
    throw err;
  }
}

async function save(file) {
  const { client, namespaceName, bucketName } = await getClient();

  const name = file.filename
    || `${Date.now()}-${Math.round(Math.random() * 1e6)}${path.extname(file.originalname || '')}`;

  const body = file.buffer
    || (file.path ? await require('fs').promises.readFile(file.path) : null);
  if (!body) throw new Error('No file content to upload');

  await client.putObject({
    namespaceName,
    bucketName,
    objectName: objectName(name),
    putObjectBody: body,
    contentLength: body.length,
    contentType: file.mimetype || 'application/octet-stream',
  });

  return name;
}

async function get(name) {
  assertSafeName(name);
  const { client, namespaceName, bucketName } = await getClient();

  try {
    const res = await client.getObject({
      namespaceName,
      bucketName,
      objectName: objectName(name),
    });
    // OCI SDK v2 returns a web ReadableStream; convert to Node stream for Express.
    const stream = res.value && typeof res.value.pipe !== 'function'
      ? Readable.fromWeb(res.value)
      : res.value;
    return {
      stream,
      contentType: res.contentType,
      contentLength: res.contentLength,
    };
  } catch (err) {
    // The SDK surfaces a missing object as a 404 ServiceError. When the retry
    // handler wraps the error, serviceCode may be stripped — check the nested
    // originalError and the message text as fallbacks.
    const code = err.statusCode ?? err.status ?? err.originalError?.statusCode;
    const svcCode = err.serviceCode ?? err.originalError?.serviceCode;
    const msg = (err.message ?? '').toLowerCase();
    if (code === 404 || svcCode === 'ObjectNotFound' || msg.includes('not found')) return null;
    throw err;
  }
}

async function remove(name) {
  assertSafeName(name);
  const { client, namespaceName, bucketName } = await getClient();
  try {
    await client.deleteObject({
      namespaceName,
      bucketName,
      objectName: objectName(name),
    });
  } catch (err) {
    if (err && err.statusCode === 404) return true;
    throw err;
  }
  return true;
}

async function exists(name) {
  assertSafeName(name);
  const { client, namespaceName, bucketName } = await getClient();
  try {
    await client.headObject({
      namespaceName,
      bucketName,
      objectName: objectName(name),
    });
    return true;
  } catch (err) {
    if (err && err.statusCode === 404) return false;
    throw err;
  }
}

module.exports = { save, get, remove, exists, name: 'oci' };
