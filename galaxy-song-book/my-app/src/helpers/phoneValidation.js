import * as Yup from 'yup';
import { AsYouType, isValidPhoneNumber } from 'libphonenumber-js';

// Global rule: "+" followed by 11-13 digits (12-14 characters total).
export const PHONE_REGEX = /^\+\d{11,13}$/;

// Live-formats as the user types, international style (e.g. "+94 77 123 4567").
// Always keeps a leading "+" — AsYouType only recognizes international
// numbers when one is present, otherwise it guesses a national format.
export function formatPhoneAsYouType(value) {
  const str = typeof value === 'string' ? value : (value ? String(value) : '');
  if (!str) return '';
  const withPlus = str.startsWith('+') ? str : `+${str.replace(/\D/g, '')}`;
  return new AsYouType().input(withPlus);
}

// Yup rule matching the global length rule AND real dialability per
// libphonenumber-js — the length check alone would accept a same-length
// string of the wrong shape. Pass { required: true } to also reject blank.
export function phoneYup({ required = false } = {}) {
  const base = Yup.string().test(
    'is-valid-phone',
    'Enter a valid phone number in international format, e.g. +14155552671',
    (value) => {
      if (!value) return true;
      const digitsOnly = value.replace(/[^\d+]/g, '');
      return PHONE_REGEX.test(digitsOnly) && isValidPhoneNumber(digitsOnly);
    }
  );
  return required ? base.required('Phone number is required') : base.nullable();
}
