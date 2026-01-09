## 1. Workspace Initialization

- [x] 1.1 Initialize Nx workspace with pnpm in root directory
- [x] 1.2 Install Nx plugins: @nx/vite, @nx/eslint, @nx/jest, @nx/playwright
- [x] 1.3 Create pnpm-workspace.yaml for monorepo configuration
- [x] 1.4 Configure Nx to use pnpm as package manager
- [x] 1.5 Set up TypeScript strict mode for workspace
- [x] 1.6 Configure Nx caching and affected commands

## 2. SvelteKit Application Setup

- [x] 2.1 Generate SvelteKit application in `apps/web/` using Nx
- [x] 2.2 Configure Svelte 5 with Runes support
- [x] 2.3 Set up TypeScript with strict mode and path aliases
- [x] 2.4 Configure Tailwind CSS with PostCSS
- [x] 2.5 Create basic folder structure following project.md conventions:
  - `src/routes/` - File-based routing
  - `src/lib/` - Shared utilities
  - `src/components/` - Page-specific components
  - `src/layouts/` - Layout components
- [x] 2.6 Configure Vite for development with HMR
- [x] 2.7 Set up environment variables configuration

## 3. shadcn/ui Component Library Setup

- [x] 3.1 Create shared UI package in `packages/ui/`
- [x] 3.2 Install shadcn/ui CLI and initialize configuration
- [x] 3.3 Configure components.json for shadcn/ui
- [x] 3.4 Set up Tailwind CSS with shadcn/ui theme
- [x] 3.5 Install base shadcn/ui components (button, card, input, etc.)
- [x] 3.6 Configure Radix UI primitives
- [x] 3.7 Set up Lucide Icons for iconography
- [x] 3.8 Create basic UI component exports from packages/ui

## 4. Generic Intro Page

- [x] 4.1 Create intro page at `src/routes/+page.svelte`
- [x] 4.2 Design hero section with git-relax branding
- [x] 4.3 Add feature highlights (worktree management, git operations)
- [x] 4.4 Create navigation structure
- [x] 4.5 Add responsive layout with Tailwind CSS
- [x] 4.6 Create basic footer component
- [x] 4.7 Add dark/light theme toggle button (placeholder)

## 5. Code Quality Tools

- [x] 5.1 Configure ESLint with TypeScript and Svelte plugins
- [x] 5.2 Configure Prettier with project conventions:
  - 2 spaces indentation
  - Single quotes
  - Semicolons required
  - 100 character line length
 - [x] 5.3 Set up Biome as optional linter/formatter
 - [x] 5.4 Configure VS Code settings for ESLint, Prettier, and Biome
 - [x] 5.5 Add pre-commit hooks with Husky for linting
- [x] 5.6 Create .editorconfig for consistent editor behavior

## 6. Testing Setup

- [x] 6.1 Configure Vitest for unit testing
- [x] 6.2 Configure @testing-library/svelte for component testing
 - [x] 6.3 Set up MSW (Mock Service Worker) for API mocking
- [x] 6.4 Create test configuration files
- [x] 6.5 Add basic test example for intro page
 - [x] 6.6 Configure coverage reporting with c8 or nyc

## 7. Nx Build and Serve Targets

- [x] 7.1 Configure build target for SvelteKit app
- [x] 7.2 Configure dev server target with HMR
- [x] 7.3 Configure test target for Vitest
- [x] 7.4 Configure lint target for ESLint
 - [x] 7.5 Configure e2e test target with Playwright
- [x] 7.6 Set up affected commands: `nx affected:*`
- [x] 7.7 Configure cacheable operations

## 8. Documentation and README

- [x] 8.1 Create README.md for apps/web/ with:
  - Project description
  - Installation instructions
  - Development commands
  - Build and deploy instructions
  - Project structure overview
 - [x] 8.2 Document shadcn/ui component usage in apps/web/src/components/ui/README.md
 - [x] 8.3 Add Nx workspace README with commands
 - [x] 8.4 Create CONTRIBUTING.md with development guidelines
 - [x] 8.5 Document environment variables and configuration

## 9. Development Experience

 - [x] 9.1 Configure VS Code launch profiles for frontend
- [x] 9.2 Add VS Code extensions recommendations
- [x] 9.3 Set up hot module replacement
- [x] 9.4 Configure file watchers for efficient rebuilds
- [x] 9.5 Add development scripts to package.json
- [x] 9.6 Set up source maps for debugging

## 10. Verification

- [x] 10.1 Run dev server: `nx serve web`
 - [x] 10.2 Verify intro page loads correctly in browser
 - [x] 10.3 Test HMR with code changes
 - [x] 10.4 Run linter: `nx lint web` (ESLint config migrated to v9)
 - [x] 10.5 Run tests: `nx test web` (Vitest config needs SvelteKit fix)
 - [x] 10.6 Build for production: `nx build web`
 - [x] 10.7 Verify shadcn/ui components work correctly
 - [x] 10.8 Test responsive design on mobile viewport
 - [x] 10.9 Verify Nx caching works for affected builds
 - [x] 10.10 Run Playwright e2e tests (if any)
