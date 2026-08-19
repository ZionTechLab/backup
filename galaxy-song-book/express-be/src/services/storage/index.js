// Storage facade. Features should use this instead of touching the filesystem
// or the OCI SDK directly.
//
// Pick the backend with STORAGE_DRIVER:
//   local (default) - files on disk in express-be/uploads, as before
//   oci             - OCI Object Storage
//
// Both drivers expose the same contract, and upload still returns an opaque
// `filename`. Existing DB rows and frontend URLs keep working after a switch.

const localDriver = require('./localDriver');
const ociDriver = require('./ociDriver');

const driverName = (process.env.STORAGE_DRIVER || 'local').toLowerCase();

const drivers = {
  local: localDriver,
  oci: ociDriver,
};

const driver = drivers[driverName];

if (!driver) {
  throw new Error(
    `Unknown STORAGE_DRIVER "${driverName}". Expected one of: ${Object.keys(drivers).join(', ')}`
  );
}

const isOci = driverName === 'oci';

module.exports = {
  /** Persist an uploaded file. Returns the storage key to record. */
  save: (file) => driver.save(file),
  /** Fetch an object: { stream, contentType, contentLength } or null. */
  get: (name) => driver.get(name),
  /** Delete an object. */
  remove: (name) => driver.remove(name),
  /** Existence check. */
  exists: (name) => driver.exists(name),

  driverName,
  isOci,
  // Multer should buffer in memory for OCI (we forward the bytes) but keep
  // writing to disk for the local driver.
  useMemoryStorage: isOci,
};
