import assert from 'node:assert';
import test, { describe, it } from 'node:test';
import { localDateStr } from './dateUtils';

describe('dateUtils', () => {
  describe('localDateStr', () => {
    it('should format date correctly', () => {
      const d = new Date(2023, 9, 15); // October 15, 2023
      assert.strictEqual(localDateStr(d), '2023-10-15');
    });

    it('should pad single digit month and day with zero', () => {
      const d = new Date(2023, 0, 5); // January 5, 2023
      assert.strictEqual(localDateStr(d), '2023-01-05');
    });
  });
});
