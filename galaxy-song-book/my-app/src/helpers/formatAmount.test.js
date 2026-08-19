import formatAmount from './formatAmount';

describe('formatAmount', () => {
  it('handles null, undefined, and empty string', () => {
    expect(formatAmount(null)).toBe('');
    expect(formatAmount(undefined)).toBe('');
    expect(formatAmount('')).toBe('');
  });

  it('formats standard integer and float numbers correctly', () => {
    expect(formatAmount(12345)).toBe('12,345.00');
    expect(formatAmount(12345.6)).toBe('12,345.60');
    expect(formatAmount(12345.67)).toBe('12,345.67');
    expect(formatAmount(12345.678)).toBe('12,345.68'); // checks rounding if toFixed is doing it, though toFixed rounds
  });

  it('formats negative numbers correctly', () => {
    expect(formatAmount(-12345)).toBe('-12,345.00');
    expect(formatAmount(-12345.6)).toBe('-12,345.60');
  });

  it('parses strings representing numbers', () => {
    expect(formatAmount('1000')).toBe('1,000.00');
    expect(formatAmount('1000.5')).toBe('1,000.50');
  });

  it('removes existing commas before parsing', () => {
    expect(formatAmount('1,000.50')).toBe('1,000.50');
    expect(formatAmount('1,234,567.89')).toBe('1,234,567.89');
    expect(formatAmount('-1,234.56')).toBe('-1,234.56');
  });

  it('handles 0 gracefully', () => {
    expect(formatAmount(0)).toBe('0.00');
    expect(formatAmount('0')).toBe('0.00');
  });

  it('returns empty string for invalid strings / non-finite inputs', () => {
    expect(formatAmount('abc')).toBe('');
    expect(formatAmount(NaN)).toBe('');
    expect(formatAmount(Infinity)).toBe('');
    expect(formatAmount(-Infinity)).toBe('');
    expect(formatAmount({})).toBe('');
    expect(formatAmount([])).toBe('0.00'); // Number([]) is 0
  });
});
