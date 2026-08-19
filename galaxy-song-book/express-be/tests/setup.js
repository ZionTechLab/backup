// Runs before each test file (jest setupFiles).
// Jest sets NODE_ENV=test, so knexfile selects the in-memory SQLite "test" env.
// Pin a deterministic JWT secret for signing/verifying tokens in tests.
process.env.JWT_SECRET = process.env.JWT_SECRET || 'test-secret';
