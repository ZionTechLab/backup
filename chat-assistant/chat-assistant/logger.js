import pino from 'pino';

const loggerOptions = {
  level: process.env.LOG_LEVEL || 'info',
};

// Use pino-pretty for human-readable logs in development, JSON in production
if (process.env.NODE_ENV !== 'production') {
  loggerOptions.transport = {
    target: 'pino-pretty',
    options: {
      colorize: true,
      translateTime: 'SYS:yyyy-mm-dd HH:MM:ss', // More readable timestamp
      ignore: 'pid,hostname', // Optional: hide pid and hostname during dev
    },
  };
}

const logger = pino(loggerOptions);

export default logger;
