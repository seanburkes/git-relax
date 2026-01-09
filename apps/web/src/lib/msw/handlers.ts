import { http, HttpResponse } from 'msw';
import type { RequestHandler } from 'msw';

// Define mock handlers
export const handlers: RequestHandler[] = [
  // Example: Mock git status endpoint
  http.get('/api/git/status', () => {
    return HttpResponse.json({
      success: true,
      data: {
        branch: 'main',
        ahead: 2,
        behind: 0,
        staged: 3,
        unstaged: 1,
        untracked: 0,
      },
    });
  }),

  // Example: Mock git operations endpoint
  http.post('/api/git/checkout', async ({ request }) => {
    const body = await request.json();
    return HttpResponse.json({
      success: true,
      data: {
        branch: body.branch,
      },
    });
  }),
];
