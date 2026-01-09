import { defineConfig } from 'vitest/config';
import { svelte } from '@sveltejs/kit/vite';

export default defineConfig({
  plugins: [svelte()],
  test: {
    include: ['src/**/*.{test,spec}.{js,ts}'],
    globals: true,
    setupFiles: ['./src/vitest-setup.ts'],
    coverage: {
      provider: 'v8',
      reporter: ['text', 'html', 'lcov'],
      exclude: [
        'node_modules/',
        '.svelte-kit/',
        'build/',
        'coverage/',
        '*.config.js',
        '*.config.ts',
        'src/lib/msw/',
      ],
    },
  },
});
