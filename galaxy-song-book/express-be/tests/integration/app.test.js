const request = require('supertest');
const app = require('../../src/app');
const db = require('../../src/database');
const { makeToken } = require('../helpers/token');

// Close the knex pool so Jest can exit cleanly.
afterAll(async () => {
  await db.destroy();
});

// These paths all short-circuit before touching application tables, so they run
// against an empty in-memory SQLite DB (no migrations/fixtures needed).
describe('auth boundary', () => {
  test('GET /api/health is public -> 200', async () => {
    const res = await request(app).get('/api/health');
    expect(res.status).toBe(200);
  });

  test('protected route without a token -> 401', async () => {
    const res = await request(app).get('/api/users');
    expect(res.status).toBe(401);
  });

  test('unknown /api route without a token -> 401 (default-deny boundary)', async () => {
    const res = await request(app).get('/api/this-route-does-not-exist');
    expect(res.status).toBe(401);
  });
});

describe('request validation', () => {
  test('POST /api/auth/login with empty body -> 400', async () => {
    const res = await request(app).post('/api/auth/login').send({});
    expect(res.status).toBe(400);
  });

  test('POST /api/item/update with a token but invalid body -> 400', async () => {
    // Authenticated, no tenant header (so tenantContext skips the DB), missing
    // required header fields -> yup rejects before the repository is reached.
    const res = await request(app)
      .post('/api/item/update')
      .set('Authorization', `Bearer ${makeToken()}`)
      .send({ header: { uom: 'pcs' } });
    expect(res.status).toBe(400);
  });
});
