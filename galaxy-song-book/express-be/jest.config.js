/** Jest config for the backend test suite. Tests live under tests/. */
module.exports = {
  testEnvironment: 'node',
  testMatch: ['**/tests/**/*.test.js'],
  setupFiles: ['<rootDir>/tests/setup.js'],
  // Integration setup runs the core migrations (plus argon2 hashing) in a hook,
  // which exceeds Jest's 5s default. Give tests and hooks more room.
  testTimeout: 30000,
  // The pino logger opens a log-file write stream when the app is required in
  // integration tests. That handle is benign but keeps the event loop alive,
  // so force a clean exit once all tests finish.
  forceExit: true,
};
