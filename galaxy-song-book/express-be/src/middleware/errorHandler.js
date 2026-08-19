const pinoHttp = require('pino-http');

class AppError extends Error {
  constructor(message, statusCode = 500, code) {
    super(message);
    this.statusCode = statusCode;
    this.code = code;
  }
}

// Central error handler
function errorHandler(err, req, res, next) {
  // Log errors using request logger (pino) when available; avoid console output
  const status = err.statusCode || inferStatusFrom(err) || 500;
  const isProd = process.env.NODE_ENV === 'production';

  // If pino-http is used, prefer its logger. Fall back to the file logger if available.
  const fileLogger = require('./logger').logger;
  const logger = req && req.log ? req.log : (fileLogger || console);
  logger.error({ err }, err.message);

  const message = isProd && status === 500
    ? 'Something went wrong!'
    : (err.name === 'ValidationError' && Array.isArray(err.errors) ? err.errors.join(', ') : err.message);

  res.status(status).json({
    error: httpStatusText(status),
    message,
    code: err.code,
  });
}

function inferStatusFrom(err) {
  // Map common library errors to HTTP status
  if (!err) return 500;
  if (err.name === 'ValidationError') return 400; // yup
  if (err.code === 'SQLITE_CONSTRAINT') return 400;
  return undefined;
}

function httpStatusText(status) {
  const map = {
    400: 'Bad Request',
    401: 'Unauthorized',
    403: 'Forbidden',
    404: 'Not Found',
    409: 'Conflict',
    422: 'Unprocessable Entity',
    500: 'Internal Server Error',
  };
  return map[status] || 'Error';
}

module.exports = { errorHandler, AppError };
