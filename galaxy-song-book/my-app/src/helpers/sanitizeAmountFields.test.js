import sanitizeAmountFields from './sanitizeAmountFields';

describe('sanitizeAmountFields', () => {
  it('removes commas from string amount fields', () => {
    const items = [
      { id: 1, amount: '1,000.50', name: 'Test' },
      { id: 2, amount: '2,345,678.00', name: 'Test 2' }
    ];
    const columns = [
      { field: 'amount', type: 'amount' },
      { field: 'name', type: 'text' }
    ];

    const result = sanitizeAmountFields(items, columns);

    expect(result).toEqual([
      { id: 1, amount: '1000.50', name: 'Test' },
      { id: 2, amount: '2345678.00', name: 'Test 2' }
    ]);
  });

  it('handles multiple amount fields', () => {
    const items = [
      { id: 1, price: '1,000', cost: '500,00', quantity: 5 },
    ];
    const columns = [
      { field: 'price', type: 'amount' },
      { field: 'cost', type: 'amount' },
      { field: 'quantity', type: 'number' }
    ];

    const result = sanitizeAmountFields(items, columns);

    expect(result).toEqual([
      { id: 1, price: '1000', cost: '50000', quantity: 5 }
    ]);
  });

  it('does not modify non-string amount fields', () => {
    const items = [
      { id: 1, amount: 1000.50 },
      { id: 2, amount: null },
      { id: 3, amount: undefined },
    ];
    const columns = [
      { field: 'amount', type: 'amount' }
    ];

    const result = sanitizeAmountFields(items, columns);

    expect(result).toEqual([
      { id: 1, amount: 1000.50 },
      { id: 2, amount: null },
      { id: 3, amount: undefined },
    ]);
  });

  it('handles fields missing from items', () => {
    const items = [
      { id: 1, name: 'Item 1' },
    ];
    const columns = [
      { field: 'amount', type: 'amount' }
    ];

    const result = sanitizeAmountFields(items, columns);

    expect(result).toEqual([
      { id: 1, name: 'Item 1' }
    ]);
  });

  it('handles empty items array', () => {
    const items = [];
    const columns = [
      { field: 'amount', type: 'amount' }
    ];

    const result = sanitizeAmountFields(items, columns);

    expect(result).toEqual([]);
  });

  it('handles empty columns array', () => {
    const items = [
      { id: 1, amount: '1,000' }
    ];
    const columns = [];

    const result = sanitizeAmountFields(items, columns);

    expect(result).toEqual([
      { id: 1, amount: '1,000' }
    ]);
  });

  it('does not mutate original items array', () => {
    const items = [
      { id: 1, amount: '1,000' }
    ];
    const columns = [
      { field: 'amount', type: 'amount' }
    ];

    const result = sanitizeAmountFields(items, columns);

    expect(result).not.toBe(items);
    expect(result[0]).not.toBe(items[0]);
    expect(items[0].amount).toBe('1,000');
  });
});
