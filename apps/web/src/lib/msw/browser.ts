import { setupWorker } from 'msw/browser';
import { handlers } from './handlers';

// Create a worker instance
export const worker = setupWorker(...handlers);

// Enable service worker in development
if (import.meta.env.DEV) {
  worker
    .start({
      onUnhandledRequest: 'bypass', // Don't log warnings for unhandled requests
    })
    .then(() => {
      console.log('🔶 MSW worker started');
    })
    .catch((error) => {
      console.error('🔴 MSW worker failed to start', error);
    });
}
