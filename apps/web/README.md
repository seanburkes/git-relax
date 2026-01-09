# Git-Relax Frontend

A modern, beautiful web interface for Git operations built with SvelteKit, Svelte 5, and shadcn/ui.

## Tech Stack

- **Framework**: SvelteKit with Svelte 5 (Runes)
- **Language**: TypeScript (strict mode)
- **UI Components**: shadcn/ui (Tailwind CSS + Radix UI)
- **Build Tool**: Vite
- **Testing**: Vitest (unit), Playwright (E2E)
- **Code Quality**: ESLint, Prettier
- **Package Manager**: pnpm
- **Monorepo**: Nx

## Getting Started

### Installation

```bash
# Install dependencies
pnpm install

# Start development server
pnpm run dev
```

### Development

```bash
# Run development server with HMR
pnpm run dev

# Run type checking
pnpm run check

# Run tests
pnpm run test

# Run linter
pnpm run lint

# Build for production
pnpm run build

# Preview production build
pnpm run preview
```

## Project Structure

```
apps/web/
├── src/
│   ├── routes/          # File-based routing (SvelteKit)
│   ├── components/       # Page-specific components
│   ├── lib/             # Shared utilities and types
│   └── layouts/         # Layout components
├── static/              # Static assets
├── package.json
├── svelte.config.js
├── vite.config.ts
├── tsconfig.json
├── tailwind.config.js
├── postcss.config.js
├── .eslintrc.json
├── .prettierrc.json
└── vitest.config.ts
```

## Nx Commands

```bash
# Run dev server via Nx
nx serve web

# Build via Nx
nx build web

# Run tests via Nx
nx test web

# Run linter via Nx
nx lint web

# Run affected commands
nx affected --graph=focus
nx affected:build --parallel
nx affected:test --parallel
```

## Code Style

- **Indentation**: 2 spaces
- **Quotes**: Single quotes
- **Semicolons**: Required
- **Line Length**: 100 characters
- **Component Naming**: PascalCase (e.g., `NavBar.svelte`)
- **File Naming**: kebab-case (e.g., `nav-bar.svelte`)
- **Function Naming**: camelCase (e.g., `fetchData`)

## Component Development

Components follow the Svelte 5 Runes pattern:

```svelte
<script lang="ts">
  let count = $state(0);
  let doubled = $derived(() => count * 2);

  function increment(): void {
    count += 1;
  }
</script>

<button on:click={increment}>
  Count: {count}
</button>
```

## Testing

```bash
# Run unit tests
pnpm run test

# Run tests with coverage
pnpm run test -- --coverage

# Run tests in watch mode
pnpm run test -- --watch
```

## Building for Production

```bash
# Build for production
pnpm run build

# Preview production build
pnpm run preview
```

Built files are output to `.svelte-kit/output/`.

## Docker

You can also run this service using Docker Compose:

```bash
# Start both frontend and backend with Docker
docker compose up

# Access frontend
http://localhost:5173

# Stop services
docker compose down
```

The Docker setup includes:
- Volume mounts for hot-reload development
- Automatic dependency installation
- Networking with backend service

See [DOCKER.md](../../DOCKER.md) for detailed Docker documentation.
