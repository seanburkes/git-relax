# Design: Svelte + shadcn Frontend Architecture

## Context

The git-relax project requires a modern web frontend to provide a beautiful, intuitive interface for Git operations, with a primary focus on worktree management. This design establishes the initial frontend architecture using SvelteKit, shadcn/ui, and Nx workspace management.

### Constraints

- Must support modern browsers (Chrome 90+, Firefox 88+, Safari 14+, Edge 90+)
- Must follow project.md conventions (kebab-case files, PascalCase components, TypeScript strict)
- Must support dark/light theming
- Must be keyboard-first for power users
- Must integrate with backend API (currently .NET git status service)
- Must enable real-time updates via WebSocket/SignalR in future phases

### Stakeholders

- Frontend developers working on the UI
- Backend developers integrating with API
- AI agents working with OpenCode integration
- End users using the git GUI

## Goals / Non-Goals

### Goals

- Establish a scalable SvelteKit frontend architecture
- Provide beautiful, accessible UI components via shadcn/ui
- Enable efficient monorepo management with Nx
- Create a welcoming intro page to showcase the application
- Support rapid development with modern tooling (Vite, HMR)
- Ensure code quality with ESLint, Prettier, and Biome
- Set up comprehensive testing with Vitest and Playwright

### Non-Goals

- Implementing specific Git operations UI (deferred to future changes)
- Real-time WebSocket integration (deferred to Phase 4)
- Advanced worktree management features (deferred to Phase 2)
- Command palette implementation (deferred to Phase 4)
- Complex state management beyond Svelte 5 Runes

## Decisions

### Decision: Use SvelteKit over other frameworks

**What:** SvelteKit as the full-stack web framework with Svelte 5 and Runes

**Why:**
- Excellent performance with compile-time optimizations
- Built-in server-side rendering for SEO and initial load
- File-based routing convention simplifies project structure
- Strong TypeScript support with strict mode
- Active community and long-term viability
- Lightweight bundle size compared to React frameworks

**Alternatives considered:**
- Next.js (React): Larger bundle size, more complex state management
- Nuxt (Vue): Similar benefits but Svelte's compile-time approach is more performant
- Vanilla Vite: Too much boilerplate for a production application

### Decision: Use shadcn/ui for component library

**What:** shadcn/ui built on Radix UI primitives with Tailwind CSS

**Why:**
- Beautiful, accessible components out of the box
- Copy-paste components (full control, no black-box dependencies)
- Built on Radix UI (industry-standard headless primitives)
- Tailwind CSS integration matches project conventions
- Excellent TypeScript support
- Easy to customize and extend
- Strong community and frequent updates

**Alternatives considered:**
- Chakra UI: Heavier bundle, more opinionated theming
- Mantine: Good but less TypeScript-friendly
- Custom components: Too much work, reinventing the wheel

### Decision: Use Nx for monorepo management

**What:** Nx workspace with pnpm for monorepo management

**Why:**
- Smart caching for faster builds and tests
- Affected commands to only build/test changed packages
- Excellent integration with Vite, ESLint, and Playwright
- Supports both frontend and backend (with @nx/dotnet plugin)
- Strong TypeScript and code generation support
- Growing ecosystem and good documentation

**Alternatives considered:**
- Turborepo: Good but less mature ecosystem for Svelte
- pnpm workspace alone: No caching, affected commands, or code generation
- Lerna: Deprecated in favor of Turborepo or Nx

### Decision: Use Vitest for unit testing

**What:** Vitest with @testing-library/svelte for component testing

**Why:**
- Native Vite integration (fast, familiar config)
- Jest-compatible API
- Excellent TypeScript support
- Fast watch mode during development
- Strong Svelte testing support

**Alternatives considered:**
- Jest: Slower, requires more complex setup with Svelte
- Mocha: Less feature-rich, more boilerplate

### Decision: Use Playwright for E2E testing

**What:** Playwright for end-to-end testing

**Why:**
- Modern, fast, reliable E2E tests
- Excellent TypeScript support
- Cross-browser testing out of the box
- Built-in fixtures and assertions
- Strong SvelteKit support
- Better debugging than Cypress

**Alternatives considered:**
- Cypress: Slower, less TypeScript-friendly
- Selenium: Outdated, harder to maintain

### Decision: Project folder structure

**What:** Structure based on Nx conventions with project.md guidelines

**Why:**
- Aligns with Nx best practices for monorepos
- Clear separation between apps and packages
- Easy to understand and maintain
- Supports future scaling

**Structure:**
```
apps/
  web/                  # SvelteKit application
    src/
      routes/          # File-based routing
      lib/             # Shared utilities
      components/      # Page-specific components
    static/            # Static assets
    package.json

packages/
  ui/                  # shadcn/ui component library
    components/        # Reusable UI components
    lib/              # Component utilities
    package.json

  shared/              # Shared types and utilities (future)
    types/
    package.json
```

### Decision: Use Prettier + ESLint + Biome

**What:** Prettier for formatting, ESLint for linting, Biome as optional alternative

**Why:**
- Prettier ensures consistent formatting across the codebase
- ESLint provides type-aware linting with TypeScript
- Biome (optional) offers faster, more modern alternative
- Pre-commit hooks ensure code quality before commits
- VS Code integration for seamless developer experience

**Configuration:**
- 2 spaces indentation
- Single quotes
- Semicolons required
- 100 character line length
- Svelte plugin support

## Risks / Trade-offs

### Risk: Svelte 5 and Runes are relatively new

**Mitigation:** Svelte 5 is approaching stable release; extensive community feedback and documentation available. Runes are the future of Svelte and align with project requirements for reactive state management.

### Risk: shadcn/ui copy-paste model requires manual updates

**Mitigation:** This is a feature, not a bug - full control over components. Updates can be managed carefully by tracking component versions. The trade-off is worth the flexibility and lack of black-box dependencies.

### Risk: Nx learning curve for team

**Mitigation:** Nx has excellent documentation and the initial setup will be documented thoroughly. The long-term benefits (caching, affected builds) outweigh the initial learning investment.

### Trade-off: Using multiple tools (ESLint, Prettier, Biome)

**Rationale:** Biome is provided as an optional, faster alternative. Teams can choose to use Biome exclusively or stick with ESLint + Prettier. This provides flexibility and future-proofs the tooling setup.

### Risk: Frontend and backend in different languages (TS vs .NET)

**Mitigation:** Shared TypeScript types will be defined in `packages/shared/` to ensure type safety across the boundary. The .NET backend will have corresponding C# models. This separation is intentional and aligns with microservices best practices.

## Migration Plan

Since this is initial setup, no migration is required. Future changes will:
1. Build on this foundation
2. Follow established conventions
3. Integrate with backend API
4. Add Git operations UI components
5. Implement real-time features

## Open Questions

1. Should we use pnpm workspace workspaces protocol or explicit Nx package exports?
   - **Recommendation:** Use explicit Nx package exports for better type safety

2. Should we set up a separate package for API client utilities?
   - **Recommendation:** Create in future when API integration begins

3. Should we use SvelteKit server endpoints for some backend operations?
   - **Recommendation:** Use .NET backend for all Git operations (separation of concerns), SvelteKit only for UI

4. Should we implement authentication/authorization in this phase?
   - **Recommendation:** No - defer to future phase when user management is needed

5. Should we add internationalization (i18n) support?
   - **Recommendation:** No - defer to future phase if needed for localization

## Technology Stack Summary

- **Framework:** SvelteKit with Svelte 5 and Runes
- **Language:** TypeScript strict mode
- **UI Components:** shadcn/ui (Radix UI + Tailwind CSS)
- **Icons:** Lucide Icons
- **Styling:** Tailwind CSS with PostCSS
- **Build Tool:** Vite
- **Monorepo:** Nx with pnpm
- **Testing:** Vitest (unit), Playwright (E2E)
- **Code Quality:** ESLint, Prettier, Biome (optional)
- **Git Hooks:** Husky
- **Editor:** VS Code with recommended extensions
