import { server } from './lib/msw/node';
import { afterEach, beforeAll } from 'vitest';

// Start the MSW server before all tests
beforeAll(() => {
  server.listen({ onUnhandledRequest: 'error' });
});

// Reset handlers after each test
afterEach(() => {
  server.resetHandlers());
});

// Close the server after all tests are done
afterAll(() => {
  server.close();
});
