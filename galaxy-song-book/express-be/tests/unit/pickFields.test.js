const { pickFields } = require('../../src/repository/pickFields');

// pickFields is the mass-assignment guard: it copies only allowlisted keys from
// a user-supplied object. These tests pin that contract.
describe('pickFields', () => {
  test('keeps only allowlisted keys, drops everything else', () => {
    const out = pickFields({ a: 1, b: 2, evil: 'x' }, ['a', 'b']);
    expect(out).toEqual({ a: 1, b: 2 });
  });

  test('drops keys whose value is undefined', () => {
    const out = pickFields({ a: 1, b: undefined }, ['a', 'b']);
    expect(out).toEqual({ a: 1 });
  });

  test('keeps an explicit null (a real value the client may set)', () => {
    expect(pickFields({ a: null }, ['a'])).toEqual({ a: null });
  });

  test('ignores allowlisted keys that are absent from the source', () => {
    expect(pickFields({ a: 1 }, ['a', 'b', 'c'])).toEqual({ a: 1 });
  });

  test('tolerates an undefined or empty source', () => {
    expect(pickFields(undefined, ['a'])).toEqual({});
    expect(pickFields({}, ['a'])).toEqual({});
  });
});
