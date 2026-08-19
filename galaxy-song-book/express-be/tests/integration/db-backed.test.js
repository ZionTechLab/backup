const request = require('supertest');
const argon2 = require('argon2');
const { randomUUID } = require('crypto');
const app = require('../../src/app');
const { db, migrateCore } = require('../helpers/db');
const { makeToken } = require('../helpers/token');

// These tests need a real schema, so they run the core migrations (which also
// seed demo tenants/companies/users/memberships) into the in-memory DB.

const LOGIN_PASSWORD = 'Secret123!';

beforeAll(async () => {
  await migrateCore();
  // Seed a user with a known password for the login tests.
  await db('mas_users').insert({
    userId: randomUUID(),
    userName: 'logintester',
    password: await argon2.hash(LOGIN_PASSWORD),
    fullName: 'Login Tester',
    email: 'logintester@test.com',
    phone: '0770000099',
    phone2: '0770000098',
    isActive: true,
  });
}, 60000);

afterAll(async () => {
  await db.destroy();
});

// Phase 1 tenant isolation: tenantContext must reject a claimed tenant/company
// the user is not a member of, and allow one they are.
describe('tenant/company context', () => {
  test('a tenant the user belongs to passes the boundary -> 200', async () => {
    const membership = await db('sec_userTenants').first();
    const res = await request(app)
      .get('/api/users/get-all')
      .set('Authorization', `Bearer ${makeToken({ sub: membership.userId })}`)
      .set('X-Tenant-Id', membership.tenantId);
    expect(res.status).toBe(200);
  });

  test('a tenant the user does NOT belong to -> 403', async () => {
    const membership = await db('sec_userTenants').first();
    const res = await request(app)
      .get('/api/users/get-all')
      .set('Authorization', `Bearer ${makeToken({ sub: membership.userId })}`)
      .set('X-Tenant-Id', randomUUID());
    expect(res.status).toBe(403);
  });

  test('a company the user does NOT belong to -> 403', async () => {
    const membership = await db('sec_userCompanies').first();
    const res = await request(app)
      .get('/api/users/get-all')
      .set('Authorization', `Bearer ${makeToken({ sub: membership.userId })}`)
      .set('X-Company-Id', randomUUID());
    expect(res.status).toBe(403);
  });
});

describe('auth login', () => {
  test('valid credentials -> 200 with a token and user', async () => {
    const res = await request(app)
      .post('/api/auth/login')
      .send({ userName: 'logintester', password: LOGIN_PASSWORD });
    expect(res.status).toBe(200);
    expect(res.body.token).toBeTruthy();
    expect(res.body.user.userName).toBe('logintester');
  });

  test('wrong password -> 401', async () => {
    const res = await request(app)
      .post('/api/auth/login')
      .send({ userName: 'logintester', password: 'not-the-password' });
    expect(res.status).toBe(401);
  });
});

describe('user create round-trip', () => {
  test('create a user, then read it back', async () => {
    const token = makeToken({ roleId: 1 }); // /update requires Admin (roleId 1)

    const created = await request(app)
      .post('/api/users/update')
      .set('Authorization', `Bearer ${token}`)
      .send({
        isUpdate: false,
        header: {
          userName: 'phasebbob',
          password: 'pw12345',
          fullName: 'Phase B Bob',
          email: 'phasebbob@test.com',
          phone: '0771112233',
          phone2: '0771112234',
          isActive: true,
        },
      });
    expect(created.status).toBe(201);
    expect(created.body.userId).toBeTruthy();

    const read = await request(app)
      .get('/api/users/get')
      .set('Authorization', `Bearer ${token}`)
      .query({ userId: created.body.userId });
    expect(read.status).toBe(200);
    expect(read.body.userName).toBe('phasebbob');
  });
});
