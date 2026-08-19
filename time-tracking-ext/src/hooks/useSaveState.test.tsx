import { test, describe, mock, afterEach } from 'node:test';
import * as assert from 'node:assert';
import { JSDOM } from 'jsdom';

const dom = new JSDOM('<!DOCTYPE html><html><body></body></html>', {
  url: 'http://localhost'
});
global.window = dom.window as any;
global.document = dom.window.document as any;
Object.defineProperty(global, 'navigator', {
  value: dom.window.navigator,
  writable: true,
  configurable: true
});
global.requestAnimationFrame = (cb) => setTimeout(cb, 0);
global.cancelAnimationFrame = (id) => clearTimeout(id);

import React from 'react';
import { cleanup } from '@testing-library/react';

afterEach(() => {
  cleanup();
});


import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { useSaveState } from './useSaveState';

// A wrapper component to test the hook
function TestComponent({ saveFn }: { saveFn: () => Promise<void> }) {
  const { saving, error, success, withSaveState } = useSaveState();

  return (
    <div>
      <div data-testid="saving">{saving.toString()}</div>
      <div data-testid="error">{error}</div>
      <div data-testid="success">{success}</div>
      <button onClick={() => withSaveState(saveFn)}>Save</button>
    </div>
  );
}

describe('useSaveState', () => {
  test('initial state', () => {
    render(<TestComponent saveFn={async () => {}} />);
    assert.strictEqual(screen.getByTestId('saving').textContent, 'false');
    assert.strictEqual(screen.getByTestId('error').textContent, '');
    assert.strictEqual(screen.getByTestId('success').textContent, '');
  });

  test('successful save', async () => {
    let resolveSave: () => void;
    const savePromise = new Promise<void>((resolve) => {
      resolveSave = resolve;
    });
    const saveFn = mock.fn(() => savePromise);

    render(<TestComponent saveFn={saveFn} />);

    fireEvent.click(screen.getByText('Save'));

    assert.strictEqual(screen.getByTestId('saving').textContent, 'true');
    assert.strictEqual(screen.getByTestId('error').textContent, '');
    assert.strictEqual(screen.getByTestId('success').textContent, '');

    resolveSave!();

    await waitFor(() => {
      assert.strictEqual(screen.getByTestId('saving').textContent, 'false');
    });

    assert.strictEqual(screen.getByTestId('success').textContent, 'Saved.');
    assert.strictEqual(saveFn.mock.calls.length, 1);
  });

  test('failed save', async () => {
    let rejectSave: (err: Error) => void;
    const savePromise = new Promise<void>((_, reject) => {
      rejectSave = reject;
    });
    const saveFn = mock.fn(() => savePromise);

    render(<TestComponent saveFn={saveFn} />);

    fireEvent.click(screen.getByText('Save'));

    assert.strictEqual(screen.getByTestId('saving').textContent, 'true');

    rejectSave!(new Error('Test error'));

    await waitFor(() => {
      assert.strictEqual(screen.getByTestId('saving').textContent, 'false');
    });

    assert.strictEqual(screen.getByTestId('error').textContent, 'Test error');
    assert.strictEqual(screen.getByTestId('success').textContent, '');
    assert.strictEqual(saveFn.mock.calls.length, 1);
  });
});
