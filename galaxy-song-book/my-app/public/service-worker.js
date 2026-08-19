/* eslint-disable no-undef, no-restricted-globals */
/* eslint-env serviceworker */
/* global workbox */
// Custom service worker using Workbox v7 modules loaded via importScripts
// Suppress verbose Workbox logs (must be set BEFORE importScripts)
// Ref: https://developer.chrome.com/docs/workbox/modules/workbox-core#disable_logging
// This keeps the console clean both in development and production.
// Remove or set to false to re-enable detailed Workbox logging.
self.__WB_DISABLE_DEV_LOGS = true; // eslint-disable-line no-underscore-dangle

importScripts('https://storage.googleapis.com/workbox-cdn/releases/7.0.0/workbox-sw.js');

self.addEventListener('message', (event) => {
  if (event.data && event.data.type === 'SKIP_WAITING') {
    self.skipWaiting();
  }
});

if (self.workbox) {
  // Extra safety: ensure debug is off even if the CDN build defaults change
  try { workbox.setConfig({ debug: false }); } catch (e) { /* noop */ }
  // Claim clients as soon as SW activates
  workbox.core.clientsClaim();

  // Precache offline fallback (no revisioning; update the string to bust cache)
  workbox.precaching.precacheAndRoute([
    { url: 'offline.html', revision: '1' },
  ]);

  // Cache the app shell (navigate requests)
  workbox.routing.registerRoute(
    ({ request }) => request.mode === 'navigate',
    new workbox.strategies.NetworkFirst({
      cacheName: 'pages',
      plugins: [
        new workbox.expiration.ExpirationPlugin({ maxEntries: 50 }),
      ],
    })
  );

  // Static assets
  workbox.routing.registerRoute(
    ({ request }) => request.destination === 'style' || request.destination === 'script' || request.destination === 'worker',
    new workbox.strategies.StaleWhileRevalidate({
      cacheName: 'static-resources',
    })
  );

  // Images
  workbox.routing.registerRoute(
    ({ request }) => request.destination === 'image',
    new workbox.strategies.CacheFirst({
      cacheName: 'images',
      plugins: [
        new workbox.expiration.ExpirationPlugin({ maxEntries: 60, maxAgeSeconds: 30 * 24 * 60 * 60 }), // 30 Days
      ],
    })
  );

  // Offline fallback for navigations
  workbox.routing.setCatchHandler(async ({ event }) => {
    if (event.request.destination === 'document') {
      return caches.match('offline.html');
    }
    return Response.error();
  });
} else {
  console.warn('Workbox could not be loaded. Offline support disabled.');
}
