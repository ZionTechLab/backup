const yup = require('yup');
const { isValidPhoneNumber } = require('libphonenumber-js');

// A number field that treats '' and null (common from form clients) as "absent"
// instead of failing the cast. Use for optional numeric/decimal columns.
const optionalNumber = () =>
  yup
    .number()
    .transform((value, original) => (original === '' || original === null ? undefined : value))
    .nullable();

// Global phone number rule: "+" followed by 11-13 digits (12-14 characters
// total), and a real, dialable number per libphonenumber-js — the length
// check alone would accept a same-length string of the wrong shape.
// Empty/nullable is allowed here; pass required: true to also reject blank.
const PHONE_REGEX = /^\+\d{11,13}$/;
const phoneNumber = ({ required = false } = {}) => {
  const base = yup.string().test(
    'is-valid-phone',
    'Enter a valid phone number in international format, e.g. +14155552671',
    (value) => {
      if (!value) return true;
      // Frontend sends it AsYouType-formatted (e.g. "+1 415 555 2671") — strip
      // the display formatting before testing the shape/validity rule.
      const digitsOnly = value.replace(/[^\d+]/g, '');
      return PHONE_REGEX.test(digitsOnly) && isValidPhoneNumber(digitsOnly);
    }
  );
  return required ? base.required('Phone number is required') : base.nullable();
};

// Standard options for every controller schema: collect all errors, drop unknown keys.
const VALIDATE_OPTS = { abortEarly: false, stripUnknown: true };

module.exports = { optionalNumber, phoneNumber, PHONE_REGEX, VALIDATE_OPTS };
