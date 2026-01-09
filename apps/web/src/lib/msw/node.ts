import { setupServer } from 'msw/node';
import { handlers } from './handlers';

// Create a server instance for Node.js testing
export const server = setupServer(...handlers);
