// MessageBoxService.js
// Singleton service for global message box management (single-active, one-shot callbacks)

class MessageBoxService {
  constructor() {
    this.listeners = [];
    this._defaults = {
      show: false,
      title: '',
      message: '',
      type: 'success',
      confirmText: 'Okay',
      cancelText: '',
      onConfirm: null,
      onClose: null,
    };
    this.options = { ...this._defaults };
  }

  subscribe(listener) {
    this.listeners.push(listener);
    // Initial call
    listener(this.options);
    return () => {
      this.listeners = this.listeners.filter((l) => l !== listener);
    };
  }

  _notify() {
    this.listeners.forEach((listener) => listener(this.options));
  }

  // Show a new dialog; resets to defaults first to avoid leaking previous callbacks/text
  show(opts = {}) {
    this.options = { ...this._defaults, ...opts, show: true };
    this._notify();
  }

  // Close/cancel the current dialog and invoke onClose once
  close() {
    const onClose = this.options.onClose;
    // set show false and clear callbacks before invoking to prevent re-entrancy leaks
    this.options = { ...this.options, show: false, onConfirm: null, onClose: null };
    this._notify();
    if (typeof onClose === 'function') {
      try { onClose(); } catch (_) { /* noop */ }
    }
  }

  // Confirm the current dialog and invoke onConfirm once
  confirm() {
    const onConfirm = this.options.onConfirm;
    // set show false and clear callbacks before invoking to prevent re-entrancy leaks
    this.options = { ...this.options, show: false, onConfirm: null, onClose: null };
    this._notify();
    if (typeof onConfirm === 'function') {
      try { onConfirm(); } catch (_) { /* noop */ }
    }
  }

  // Promise-based confirm helper; resolves true on confirm, false on cancel/close
  confirmAsync(opts = {}) {
    return new Promise((resolve) => {
      this.show({
        ...opts,
        onConfirm: () => resolve(true),
        onClose: () => resolve(false),
      });
    });
  }
}

const instance = new MessageBoxService();
export default instance;
