const express = require('express');
const cors = require('cors');
const helmet = require('helmet');
require('dotenv').config();

const loggerMiddleware = require('./middleware/logger');
const appLogger = loggerMiddleware.appLogger;

if (process.env.NODE_ENV === 'production' && !process.env.JWT_SECRET) {
  throw new Error('JWT_SECRET environment variable must be set in production');
}
if (!process.env.JWT_SECRET) {
  appLogger.warn('JWT_SECRET is not set — using insecure default. Set JWT_SECRET before deploying.');
}

const fs = require('fs');
const https = require('https');
const path = require('path');


// Route setup moved to a separate module
const setupRoutes = require('./routes');
const setupSwagger = require('./swagger');
const { errorHandler } = require('./middleware/errorHandler');

const app = express();
const PORT = process.env.PORT || 3000;

// Set security headers for all responses
app.use((req, res, next) => {
  res.setHeader('Cross-Origin-Opener-Policy', 'same-origin');
  res.setHeader('Origin-Agent-Cluster', '?1');
  next();
});


// Middleware
app.use(helmet());

// CORS allowlist. Set CORS_ORIGINS to a comma-separated list of allowed origins
// in production. Defaults to local dev origins when unset.
const allowedOrigins = (process.env.CORS_ORIGINS || 'http://localhost:3000,http://localhost:3001')
  .split(',')
  .map((o) => o.trim())
  .filter(Boolean);

app.use(cors({
  origin(origin, callback) {
    // Allow non-browser clients (no Origin header) and any allowlisted origin.
    if (!origin || allowedOrigins.includes(origin)) return callback(null, true);
    return callback(new Error(`Origin ${origin} not allowed by CORS`));
  },
}));
app.use(loggerMiddleware);
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Serve uploaded files from /uploads publicly. Only meaningful for the local
// storage driver — with STORAGE_DRIVER=oci nothing is written to local disk, so
// the static mount is skipped and reads go through /api/upload instead.
const storageService = require('./services/storage');
if (!storageService.isOci) {
  app.use('/uploads', express.static(path.join(__dirname, '..', 'uploads'), {
    // Same reason as in routes/upload.js: helmet's default CORP of "same-origin"
    // stops the frontend origin from rendering these in an <img>.
    setHeaders: (res) => res.setHeader('Cross-Origin-Resource-Policy', 'cross-origin'),
  }));
}

// Public read endpoints (/api/upload?name=… and /api/uploads/:name) are handled
// by src/routes/upload.js, which reads through the storage service so the same
// URLs work for both local disk and OCI Object Storage.

// Swagger docs
setupSwagger(app);

// Register routes (health, api endpoints, 404 handler are handled in this module)
setupRoutes(app);

// Error handler (centralized)
app.use(errorHandler);

// Runtime-only side effects. Guarded so `require('./app')` (tests) stays pure:
// only `node src/app.js` (require.main === module) starts servers and exit hooks.
if (require.main === module) {
  const startServer = () => {
    app.listen(PORT, () => {
      appLogger.info({ port: PORT }, 'Service Plus API server running');
      appLogger.info({ url: `http://localhost:${PORT}/api/health` }, 'Health check URL');
    });
  };

  if (process.env.NODE_ENV === 'production' && process.env.DB_CLIENT === 'sqlite3') {
    // /tmp on App Engine is wiped on every restart — rebuild the schema before serving traffic.
    require('./migrate')(appLogger)
      .then(startServer)
      .catch((err) => {
        appLogger.error({ err }, 'migration failed on boot');
        process.exit(1);
      });
  } else {
    startServer();
  }

  // Log uncaught exceptions and unhandled rejections to file (no console output)
  process.on('uncaughtException', (err) => {
    if (appLogger && typeof appLogger.error === 'function') {
      appLogger.error({ err }, 'uncaughtException');
    }
    process.exit(1);
  });

  process.on('unhandledRejection', (reason) => {
    if (appLogger && typeof appLogger.error === 'function') {
      appLogger.error({ reason }, 'unhandledRejection');
    }
    process.exit(1);
  });

  // HTTPS support for production on a bare VM/on-prem host that terminates its own TLS.
  // Skip on App Engine: GAE terminates TLS at its load balancer and forwards plain HTTP to $PORT.
  if (process.env.NODE_ENV === 'production' && process.env.SSL_KEY_PATH && !process.env.GAE_APPLICATION) {
    const sslOptions = {
      key: fs.readFileSync(process.env.SSL_KEY_PATH),
      cert: fs.readFileSync(process.env.SSL_CERT_PATH)
    };
    https.createServer(sslOptions, app).listen(443, () => {
      appLogger.info('Service Plus API server running on port 443 (HTTPS)');
    });
  }
}

module.exports = app;
