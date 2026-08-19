// Lightweight service worker registration for CRA + Workbox
export function register() {
  if ('serviceWorker' in navigator) {
    const swUrl = `${process.env.PUBLIC_URL}/service-worker.js`;
    window.addEventListener('load', () => {
      navigator.serviceWorker
        .register(swUrl)
        .then((registration) => {
          // Reload once the new worker takes control.
          let reloading = false;
          navigator.serviceWorker.addEventListener('controllerchange', () => {
            if (reloading) return;
            reloading = true;
            window.location.reload();
          });

          registration.onupdatefound = () => {
            const installingWorker = registration.installing;
            if (installingWorker) {
              installingWorker.onstatechange = () => {
                if (installingWorker.state === 'installed' && navigator.serviceWorker.controller) {
                  // New build ready. Activate it now instead of waiting for all tabs to close.
                  installingWorker.postMessage({ type: 'SKIP_WAITING' });
                }
              };
            }
          };
        })
        .catch((error) => {
          console.error('Service worker registration failed:', error);
        });
    });
  }
}

export function unregister() {
  if ('serviceWorker' in navigator) {
    navigator.serviceWorker.ready.then((registration) => {
      registration.unregister();
    });
  }
}
