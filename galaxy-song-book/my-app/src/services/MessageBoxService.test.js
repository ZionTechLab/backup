import { jest } from '@jest/globals';

describe('MessageBoxService', () => {
  let messageBoxService;

  beforeEach(() => {
    jest.resetModules();
    messageBoxService = require('./MessageBoxService').default;
  });

  it('should have initial default options', () => {
    expect(messageBoxService.options).toEqual({
      show: false,
      title: '',
      message: '',
      type: 'success',
      confirmText: 'Okay',
      cancelText: '',
      onConfirm: null,
      onClose: null,
    });
  });

  it('should subscribe a listener and call it immediately with options', () => {
    const listener = jest.fn();
    const unsubscribe = messageBoxService.subscribe(listener);

    expect(listener).toHaveBeenCalledTimes(1);
    expect(listener).toHaveBeenCalledWith(messageBoxService.options);

    unsubscribe();
  });

  it('unsubscribe should remove the listener', () => {
    const listener = jest.fn();
    const unsubscribe = messageBoxService.subscribe(listener);

    // clear initial call
    listener.mockClear();

    unsubscribe();

    messageBoxService.show({ message: 'test' });
    expect(listener).not.toHaveBeenCalled();
  });

  it('show should update options and notify listeners', () => {
    const listener = jest.fn();
    messageBoxService.subscribe(listener);
    listener.mockClear();

    messageBoxService.show({ message: 'Hello World', title: 'Test Title' });

    expect(listener).toHaveBeenCalledTimes(1);
    expect(listener).toHaveBeenCalledWith(expect.objectContaining({
      show: true,
      message: 'Hello World',
      title: 'Test Title',
    }));
  });

  it('close should update options, notify listeners, and invoke onClose once', () => {
    const onClose = jest.fn();
    messageBoxService.show({ message: 'test', onClose });

    const listener = jest.fn();
    messageBoxService.subscribe(listener);
    listener.mockClear();

    messageBoxService.close();

    // Check if options are reset properly for callbacks and show=false
    expect(listener).toHaveBeenCalledTimes(1);
    expect(listener).toHaveBeenCalledWith(expect.objectContaining({
      show: false,
      onClose: null,
      onConfirm: null,
    }));

    // Check if onClose was called
    expect(onClose).toHaveBeenCalledTimes(1);
  });

  it('close should handle onClose throwing an error gracefully', () => {
    const onClose = jest.fn(() => { throw new Error('Close Error'); });
    messageBoxService.show({ message: 'test', onClose });

    expect(() => {
      messageBoxService.close();
    }).not.toThrow();

    expect(onClose).toHaveBeenCalledTimes(1);
  });

  it('confirm should update options, notify listeners, and invoke onConfirm once', () => {
    const onConfirm = jest.fn();
    messageBoxService.show({ message: 'test', onConfirm });

    const listener = jest.fn();
    messageBoxService.subscribe(listener);
    listener.mockClear();

    messageBoxService.confirm();

    // Check if options are reset properly for callbacks and show=false
    expect(listener).toHaveBeenCalledTimes(1);
    expect(listener).toHaveBeenCalledWith(expect.objectContaining({
      show: false,
      onClose: null,
      onConfirm: null,
    }));

    // Check if onConfirm was called
    expect(onConfirm).toHaveBeenCalledTimes(1);
  });

  it('confirm should handle onConfirm throwing an error gracefully', () => {
    const onConfirm = jest.fn(() => { throw new Error('Confirm Error'); });
    messageBoxService.show({ message: 'test', onConfirm });

    expect(() => {
      messageBoxService.confirm();
    }).not.toThrow();

    expect(onConfirm).toHaveBeenCalledTimes(1);
  });

  it('confirmAsync should return a promise that resolves to true on confirm', async () => {
    const promise = messageBoxService.confirmAsync({ message: 'Async Confirm' });
    messageBoxService.confirm();

    const result = await promise;
    expect(result).toBe(true);
  });

  it('confirmAsync should return a promise that resolves to false on close', async () => {
    const promise = messageBoxService.confirmAsync({ message: 'Async Close' });
    messageBoxService.close();

    const result = await promise;
    expect(result).toBe(false);
  });
});
