const express = require('express');
const storage = require('../services/storage');

const router = express.Router();

// Shared handler for both /api/upload?name=<file> and /api/uploads/:name.
//
// Reads through the storage service, so the same URLs work whether the bytes
// are on local disk or in OCI Object Storage. OCI credentials stay server-side:
// the browser only ever talks to this endpoint.
async function serveObject(name, req, res) {
  if (!name) {
    return res.status(400).json({ error: 'Missing "name" query parameter' });
  }

  let object;
  try {
    object = await storage.get(name);
  } catch (err) {
    // Drivers throw a 400-tagged error for traversal attempts / bad names.
    if (err.status === 400) return res.status(400).json({ error: err.message });
    req.log?.error?.({ err, name }, 'failed to read object from storage');
    return res.status(500).json({ error: 'Failed to read file' });
  }

  if (!object) return res.status(404).json({ error: 'File not found' });

  // helmet() defaults Cross-Origin-Resource-Policy to "same-origin", which makes
  // the browser download these bytes and then refuse to render them in an <img>
  // on a different origin (React dev server on :3001 vs API on :3000).
  // These objects are already served from a public, pre-auth route, so relax
  // CORP for them specifically rather than weakening helmet globally.
  res.setHeader('Cross-Origin-Resource-Policy', 'cross-origin');

  // Local driver: hand off to sendFile so Express sets Content-Type and
  // supports range requests.
  if (object.localPath) {
    return res.sendFile(object.localPath, (err) => {
      if (err && !res.headersSent) {
        return res.status(500).json({ error: 'Failed to send file' });
      }
    });
  }

  if (object.contentType) res.setHeader('Content-Type', object.contentType);
  if (object.contentLength != null) res.setHeader('Content-Length', object.contentLength);
  // Uploaded assets are immutable (filenames are unique per upload).
  res.setHeader('Cache-Control', 'private, max-age=31536000, immutable');

  if (req.method === 'HEAD') return res.end();

  object.stream.on('error', (err) => {
    req.log?.error?.({ err, name }, 'stream error while sending object');
    if (!res.headersSent) res.status(500).json({ error: 'Failed to send file' });
    else res.destroy(err);
  });

  return object.stream.pipe(res);
}

// Handle /api/upload for GET/HEAD and reject other methods. This ensures requests
// to the path won't fall through to later middleware (like `authenticate`).
router.all('/upload', async (req, res, next) => {
  if (req.method !== 'GET' && req.method !== 'HEAD') {
    return res.status(405).json({ error: 'Method Not Allowed' });
  }
  try {
    return await serveObject(req.query.name, req, res);
  } catch (err) {
    return next(err);
  }
});

// Plural form used by some hosting environments: /api/uploads/<filename>
router.all('/uploads/:name', async (req, res, next) => {
  if (req.method !== 'GET' && req.method !== 'HEAD') {
    return res.status(405).json({ error: 'Method Not Allowed' });
  }
  try {
    return await serveObject(req.params.name, req, res);
  } catch (err) {
    return next(err);
  }
});

module.exports = router;
