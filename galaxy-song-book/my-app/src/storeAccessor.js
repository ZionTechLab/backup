// Lightweight accessor to expose Redux state to non-React modules (e.g., axios middleware)
// without importing the store directly (avoids circular dependencies).
//
// Initialization contract: setStore(store) MUST be called in index.js before any
// code that calls getState() or dispatch(). Violations throw in development so the
// ordering error is caught immediately rather than silently producing undefined state.

let _store = null;

export function setStore(store) {
  _store = store;
}

export function getState() {
  if (!_store) {
    throw new Error('storeAccessor.getState() called before setStore(). Ensure setStore(store) runs in index.js before registering axios interceptors.');
  }
  return _store.getState();
}

export function dispatch(action) {
  if (!_store) {
    throw new Error('storeAccessor.dispatch() called before setStore(). Ensure setStore(store) runs in index.js before registering axios interceptors.');
  }
  return _store.dispatch(action);
}
