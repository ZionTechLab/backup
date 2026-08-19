const yup = require('yup');
const { optionalNumber, VALIDATE_OPTS } = require('../../src/middleware/validation');

// optionalNumber must tolerate the '' / null that form clients send for blank
// numeric inputs, instead of failing the cast, while still rejecting junk.
describe('optionalNumber', () => {
  const schema = yup.object({ n: optionalNumber() });

  test("empty string is treated as absent", async () => {
    await expect(schema.validate({ n: '' }, VALIDATE_OPTS)).resolves.toEqual({});
  });

  test('null is treated as absent', async () => {
    await expect(schema.validate({ n: null }, VALIDATE_OPTS)).resolves.toEqual({});
  });

  test('a numeric string casts to a number', async () => {
    await expect(schema.validate({ n: '42' }, VALIDATE_OPTS)).resolves.toEqual({ n: 42 });
  });

  test('a non-numeric value is rejected', async () => {
    await expect(schema.validate({ n: 'abc' }, VALIDATE_OPTS)).rejects.toThrow();
  });
});

// Sanity-check the shared validate options collect all errors and drop unknowns.
describe('VALIDATE_OPTS', () => {
  const schema = yup.object({ a: yup.string().required(), b: yup.string().required() });

  test('stripUnknown removes keys not in the schema', async () => {
    const out = await schema.validate({ a: 'x', b: 'y', extra: 'drop me' }, VALIDATE_OPTS);
    expect(out).toEqual({ a: 'x', b: 'y' });
  });

  test('abortEarly:false reports every missing field at once', async () => {
    await expect(schema.validate({}, VALIDATE_OPTS)).rejects.toMatchObject({
      errors: expect.arrayContaining([
        expect.stringContaining('a is a required field'),
        expect.stringContaining('b is a required field'),
      ]),
    });
  });
});
