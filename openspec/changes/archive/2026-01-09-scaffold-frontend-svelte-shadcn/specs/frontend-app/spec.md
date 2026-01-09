## ADDED Requirements

### Requirement: SvelteKit Application Structure
The frontend application SHALL be a SvelteKit application with Svelte 5 and Runes support.

#### Scenario: Application initialization
- **WHEN** the application is initialized with Nx
- **THEN** a SvelteKit app is created in `apps/web/`
- **AND** Svelte 5 is configured with Runes (`$state`, `$derived`, `$effect`)
- **AND** TypeScript strict mode is enabled
- **AND** file-based routing is configured in `src/routes/`

#### Scenario: Folder structure follows conventions
- **WHEN** the application is scaffolded
- **THEN** the following structure is created:
  - `src/routes/` for file-based routing
  - `src/lib/` for shared utilities
  - `src/components/` for page-specific components
  - `src/layouts/` for layout components
  - `static/` for static assets

#### Scenario: Development server runs
- **WHEN** a developer runs `nx serve web`
- **THEN** Vite development server starts
- **AND** Hot Module Replacement (HMR) is active
- **AND** changes are reflected in the browser without reload

### Requirement: TypeScript Configuration
The frontend application SHALL use TypeScript with strict mode and path aliases.

#### Scenario: Strict mode enabled
- **WHEN** TypeScript is configured
- **THEN** `strict` mode is enabled in tsconfig.json
- **AND** no `any` types are allowed
- **AND** explicit return types are required for public APIs
- **AND** type checking errors prevent compilation

#### Scenario: Path aliases configured
- **WHEN** TypeScript is configured
- **THEN** path aliases are set up:
  - `$lib` → `src/lib`
  - `$components` → `src/components`
  - `$layouts` → `src/layouts`
- **AND** imports can use these aliases

### Requirement: Tailwind CSS Configuration
The frontend application SHALL use Tailwind CSS with PostCSS for styling.

#### Scenario: Tailwind CSS is configured
- **WHEN** the application is scaffolded
- **THEN** Tailwind CSS is installed and configured
- **AND** PostCSS is configured with Tailwind plugin
- **AND** Tailwind classes are available in Svelte components
- **AND** Tailwind config follows project conventions (colors, spacing)

#### Scenario: Dark mode support
- **WHEN** the application is configured
- **THEN** Tailwind CSS supports dark mode
- **AND** a theme toggle mechanism is available (placeholder in initial implementation)

### Requirement: Generic Intro Page
The frontend application SHALL provide a generic intro page showcasing the git-relax application.

#### Scenario: Intro page loads
- **WHEN** a user visits the root URL
- **THEN** a generic intro page is displayed
- **AND** the page includes:
  - Hero section with git-relax branding
  - Feature highlights (worktree management, git operations)
  - Navigation structure
  - Basic footer
- **AND** the design is responsive for mobile and desktop

#### Scenario: Intro page styling
- **WHEN** the intro page is rendered
- **THEN** Tailwind CSS classes are used for styling
- **AND** shadcn/ui components are used where appropriate
- **AND** Lucide Icons are used for visual elements
- **AND** the design follows modern, clean aesthetic

### Requirement: Nx Build Targets
The frontend application SHALL have Nx build, serve, test, and lint targets configured.

#### Scenario: Build target
- **WHEN** a developer runs `nx build web`
- **THEN** the SvelteKit application is built for production
- **AND** static assets are generated
- **AND** the output is optimized for deployment

#### Scenario: Serve target
- **WHEN** a developer runs `nx serve web`
- **THEN** the development server starts
- **AND** HMR is enabled
- **AND** the application is available at localhost:5173

#### Scenario: Test target
- **WHEN** a developer runs `nx test web`
- **THEN** Vitest runs unit tests
- **AND** tests are executed with coverage reporting
- **AND** failing tests prevent CI from passing

#### Scenario: Lint target
- **WHEN** a developer runs `nx lint web`
- **THEN** ESLint runs on the web application
- **AND** code style violations are reported
- **AND** the check fails on errors

#### Scenario: E2E target
- **WHEN** a developer runs `nx e2e web-e2e`
- **THEN** Playwright runs end-to-end tests
- **AND** tests execute in headless mode by default
- **AND** test results are reported

### Requirement: Code Quality Tools
The frontend application SHALL use ESLint, Prettier, and optional Biome for code quality.

#### Scenario: ESLint configuration
- **WHEN** ESLint is configured
- **THEN** TypeScript plugin is enabled
- **AND** Svelte plugin is enabled
- **AND** rules enforce project conventions
- **AND** type-aware linting is enabled

#### Scenario: Prettier configuration
- **WHEN** Prettier is configured
- **THEN** formatting rules match project conventions:
  - 2 spaces indentation
  - Single quotes
  - Semicolons required
  - 100 character line length
- **AND** Svelte plugin is configured

#### Scenario: Pre-commit hooks
- **WHEN** a developer commits changes
- **THEN** Husky runs pre-commit hooks
- **AND** ESLint checks the staged files
- **AND** Prettier formats the staged files
- **AND** the commit is blocked if checks fail

#### Scenario: VS Code integration
- **WHEN** a developer opens the project in VS Code
- **THEN** recommended extensions are suggested
- **AND** ESLint, Prettier, and Svelte extensions are included
- **AND** settings are configured for consistent behavior

### Requirement: Testing Configuration
The frontend application SHALL use Vitest for unit testing and Playwright for E2E testing.

#### Scenario: Vitest setup
- **WHEN** tests are configured
- **THEN** Vitest is installed and configured
- **AND** @testing-library/svelte is available for component testing
- **AND** MSW (Mock Service Worker) is configured for API mocking
- **AND** tests use `*.test.ts` or `*.spec.ts` naming

#### Scenario: Playwright setup
- **WHEN** E2E tests are configured
- **THEN** Playwright is installed and configured
- **AND** browsers are installed (Chromium, Firefox, WebKit)
- **AND** tests use `*.spec.ts` naming
- **AND** tests can run in headless or headed mode

### Requirement: Vite Configuration
The frontend application SHALL use Vite for fast builds and development.

#### Scenario: Vite configuration
- **WHEN** Vite is configured
- **THEN** SvelteKit plugin is enabled
- **AND** TypeScript is enabled
- **AND** source maps are enabled for development
- **AND** production builds are optimized
- **AND** HMR is configured for Svelte components

#### Scenario: Environment variables
- **WHEN** environment variables are needed
- **THEN** `.env` files are supported
- **AND** variables are prefixed with `VITE_` for client-side access
- **AND** server-side variables are available in `.env` or `.env.private`
