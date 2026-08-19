const request = require('supertest');
const app = require('../../src/app');

describe('SongBook Routes Authentication', () => {
  it('should require authentication for POST /api/song-book/update', async () => {
    const res = await request(app)
      .post('/api/song-book/update')
      .send({
        isUpdate: false,
        title: 'Amazing Grace',
        lyrics: 'Amazing grace...',
        language: 'EN'
      });

    expect(res.statusCode).toBe(401);
  });
});
