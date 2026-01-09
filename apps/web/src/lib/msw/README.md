# MSW (Mock Service Worker)

This directory contains Mock Service Worker configuration for API mocking in tests and development.

## Setup

### For Browser (Development)

The MSW worker is automatically initialized in development mode. Import the browser setup in your app's entry point:

```typescript
import './lib/msw/browser';
```

### For Node.js Tests

Import the server setup in your test files:

```typescript
import { server } from '$lib/msw/node';

beforeAll(() => server.listen());
afterEach(() => server.resetHandlers());
afterAll(() => server.close());
```

## Handlers

Define your mock API handlers in `handlers.ts`:

```typescript
import { http, HttpResponse } from 'msw';

export const handlers: RequestHandler[] = [
  http.get('/api/endpoint', () => {
    return HttpResponse.json({ data: 'mocked' });
  }),
];
```

## Usage

### Dynamic Handlers

You can override handlers in tests:

```typescript
server.use(
  http.get('/api/endpoint', () => {
    return HttpResponse.json({ data: 'overridden' });
  })
);
```

### Request Matching

MSW supports various matching strategies:

- By method: `http.get`, `http.post`, `http.put`, etc.
- By path: `http.get('/api/users/:id')`
- By query parameters: `http.get('/api/users', ({ request }) => { ... })`

## Documentation

For more information, see the [MSW documentation](https://mswjs.io/).
