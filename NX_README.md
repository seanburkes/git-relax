# Git Relax - Nx Workspace

This is a monorepo managed by Nx for the git-relax project, containing multiple applications and packages.

## Workspace Structure

```
git-relax/
├── apps/
│   ├── backend/          # .NET backend API
│   └── web/             # SvelteKit frontend application
├── packages/
│   └── domain-git/      # Domain-specific Git operations
└── openspec/           # Change proposals and specifications
```

## Getting Started

### Prerequisites

- Node.js 18+
- pnpm 8+
- .NET 8+ (for backend)

### Installation

```bash
# Install dependencies
pnpm install

# Install Playwright browsers (for e2e tests)
pnpm run e2e:install
```

## Docker Setup

You can also run the entire stack using Docker Compose:

```bash
# Start both services with a single command
docker compose up

# Access services
# Frontend: http://localhost:5173
# Backend API: http://localhost:5000
# Swagger UI: http://localhost:5000/swagger

# Stop services
docker compose down
```

The Docker setup includes:
- Hot-reload development for both frontend and backend
- Volume mounts for instant code updates
- Access to local `~/src/` for Git operations
- Automatic dependency installation

See [DOCKER.md](DOCKER.md) for comprehensive Docker documentation and troubleshooting.

## Available Scripts

### Nx Commands

```bash
# Development
nx serve web            # Start SvelteKit dev server
nx serve backend        # Start .NET backend (if applicable)

# Building
nx build web            # Build SvelteKit for production
nx build backend        # Build .NET backend

# Testing
nx test web             # Run unit tests with Vitest
nx e2e web             # Run e2e tests with Playwright
nx test backend         # Run .NET tests

# Linting and Formatting
nx lint web             # Run ESLint on web app
nx lint backend         # Run dotnet format on backend
pnpm lint:biome        # Run Biome linter
pnpm format            # Format code with Biome
```

### Workspace-wide Commands

```bash
# Run command on all projects
nx run-many -t build --all

# Run on affected projects only
nx affected:build       # Build projects affected by changes
nx affected:test        # Test affected projects
nx affected:lint       # Lint affected projects

# Show project graph
nx graph

# Show available projects
nx show projects
```

## Project-specific Commands

### Web Application (SvelteKit)

```bash
cd apps/web
pnpm dev               # Start dev server
pnpm build             # Build for production
pnpm preview           # Preview production build
pnpm test              # Run Vitest unit tests
pnpm test:coverage     # Run tests with coverage
pnpm e2e              # Run Playwright e2e tests
pnpm e2e:ui           # Run e2e tests with UI
pnpm check             # Run Svelte type checking
```

## Nx Features

### Caching

Nx caches build and test results to speed up subsequent runs. Cache is stored in `.nx/cache`.

To bypass cache:

```bash
nx build web --skip-nx-cache
```

To reset cache:

```bash
nx reset
```

### Affected Commands

Run commands only on projects affected by your changes:

```bash
nx affected:build
nx affected:test
nx affected:lint
```

This is especially useful in CI/CD pipelines.

## Configuration

- **Nx Configuration:** `nx.json`
- **Package Manager:** `pnpm` (configured in `pnpm-workspace.yaml`)
- **TypeScript:** Base config in `tsconfig.base.json`

## Development Workflow

1. Create a new feature branch
2. Make changes to affected projects
3. Run tests: `nx affected:test`
4. Run linters: `nx affected:lint`
5. Build affected projects: `nx affected:build`
6. Commit changes (pre-commit hooks will run linting)

## Learn More

- [Nx Documentation](https://nx.dev)
- [SvelteKit Documentation](https://kit.svelte.dev)
- [Vitest Documentation](https://vitest.dev)
- [Playwright Documentation](https://playwright.dev)
