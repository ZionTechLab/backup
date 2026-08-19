const pino = require('pino');
const pinoHttp = require('pino-http');
const path = require('path');
const fs = require('fs');

const logDir = process.env.GAE_APPLICATION
  ? path.join(require('os').tmpdir(), 'logs')
  : path.join(__dirname, '..', '..', 'logs');
if (!fs.existsSync(logDir)) {
  fs.mkdirSync(logDir, { recursive: true });
}

// Request logger — file only (no console output)
const requestLogFile = path.join(logDir, 'requests.log');
const requestLogger = pino(
  { level: process.env.LOG_LEVEL || 'info' },
  pino.destination({ dest: requestLogFile, mkdir: true, sync: true })
);

const requestMiddleware = pinoHttp({ logger: requestLogger });

// Application logger — stdout + file
const appLogFile = path.join(logDir, 'app.log');
const appLogger = pino(
  { level: process.env.APP_LOG_LEVEL || process.env.LOG_LEVEL || 'info' },
  pino.multistream([
    { stream: process.stdout },
    { stream: pino.destination({ dest: appLogFile, mkdir: true, sync: true }) },
  ])
);

requestMiddleware.requestLogger = requestLogger;
requestMiddleware.appLogger = appLogger;

module.exports = requestMiddleware;
