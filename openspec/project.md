# Project Context

## Purpose

**git-relax** is a modern web-based GUI for Git operations, heavily inspired by LazyGit, but with a primary focus on **Git Worktree management** for AI-assisted development workflows. The application is designed to:

- Provide a beautiful, intuitive web interface for all common Git operations
- **Specialize in worktree management** - enabling multiple independent AI agent instances (like OpenCode) to work on separate worktrees simultaneously
- Streamline code review workflows for AI-generated code
- Enable rapid merging and synchronization between worktree branches and main
- Support concurrent development across multiple feature branches without switching context
- Offer real-time collaboration between AI agents through worktree isolation

The project follows a spec-driven development approach using OpenSpec, ensuring clear requirements, well-planned changes, and maintainable architecture.

## Tech Stack

### Frontend
- **SvelteKit** - Full-stack web framework with SSR and client-side routing
- **Svelte 5** - Reactive component library with Runes (latest version)
- **TypeScript** - Strict type safety across the entire frontend
- **shadcn/ui** - Beautiful, accessible component library built on Radix UI and Tailwind CSS
- **Tailwind CSS** - Utility-first CSS framework for rapid UI development
- **Lucide Icons** - Consistent icon set for UI elements
- **Vite** - Fast build tool and dev server with HMR

### Backend
- **.NET 8+** (preferred) - Modern, high-performance web framework
  - ASP.NET Core Web API for REST/Realtime endpoints
  - SignalR for real-time Git operations and updates
  - LibGit2Sharp or LibGit2 for Git operations
  - **OR** **Rust** (alternative) - Systems programming language
    - Axum or Actix-web for web server
    - gitoxide (Rust library for Git) for Git operations
    - Tokio for async runtime

### Build & Tooling
- **Nx** - Monorepo management with smart caching and affected builds
- **Vite** - Build tool and dev server with HMR
- **pnpm** - Fast, disk space efficient package manager (or npm/yarn)

### Testing
- **Vitest** - Fast unit testing for frontend code and Svelte components
- **Playwright** - End-to-end testing of the web application
- **xUnit** or **NUnit** (.NET) / **Rust native tests** - Backend testing
- **Nx cache** - Efficient test runs for affected packages

### Code Quality
- **ESLint** - Linting with TypeScript support and Svelte plugin
- **Prettier** - Code formatting
- **Biome** (optional) - Fast linter and formatter alternative
- **TypeScript strict** - No `any` types, full type safety enforced

### Developer Experience
- **Hot Module Replacement** - Instant feedback during development
- **Real-time updates** - Git status changes reflected immediately via WebSocket/SignalR
- **Command palette** - Quick access to all features (like LazyGit)
- **Keyboard navigation** - Full keyboard support for power users

## Project Conventions

### Code Style

#### Formatting
- Use **Prettier** with default settings
- **2 spaces** for indentation (no tabs)
- **Semicolons** required
- **Single quotes** for strings unless containing quotes
- **Trailing commas** in multi-line structures
- **Max line length**: 100 characters

#### Naming Conventions
- **Files**: kebab-case (e.g., `worktree-manager.svelte`, `git-service.ts`)
- **Components**: PascalCase (e.g., `WorktreeList.svelte`, `CommitGraph`)
- **Functions/Variables**: camelCase (e.g., `fetchWorktreeStatus`, `isLoading`)
- **Constants**: UPPER_SNAKE_CASE (e.g., `MAX_RETRIES`, `DEFAULT_TIMEOUT`)
- **Types/Interfaces**: PascalCase (e.g., `Worktree`, `Commit`, `Branch`)
- **Packages**: kebab-case (e.g., `@git-relax/shared`, `@git-relax/ui`)
- **Backend (.NET)**: PascalCase for classes/methods, camelCase for properties (C# conventions)
- **Backend (Rust)**: snake_case for functions/variables, PascalCase for types (Rust conventions)

#### TypeScript
- **Strict mode** enabled - no `any` types allowed
- Use `interface` for object shapes, `type` for unions/primitives
- Explicit return types for public APIs
- Prefer `const` over `let`, `readonly` where appropriate
- Use type guards and discriminated unions for complex logic
- Use Svelte 5 Runes (`$state`, `$derived`, `$effect`) for reactivity

#### Frontend (Svelte)
- Use **Svelte 5** syntax with Runes
- Components should be small and focused (<200 lines when possible)
- Use `class:` directives over CSS-in-JS
- Prefer Tailwind utility classes over custom CSS
- Use `bind:` directives sparingly - prefer explicit event handlers
- Accessibility: proper ARIA labels, keyboard navigation, focus management

#### Backend (.NET - if chosen)
- Follow **C# coding conventions**
- Async methods should end with `Async` suffix
- Use `record` types for immutable data
- Dependency injection for services
- Use `IActionResult` or `T` for API responses
- Use `ILogger<T>` for logging
- Follow REST conventions for API endpoints

#### Backend (Rust - if chosen)
- Follow **Rust naming conventions**
- Use `Result<T, E>` for error handling
- Async code with `async/await` and `tokio`
- Prefer `thiserror` or `anyhow` for error types
- Use `serde` for serialization
- Follow clippy lints

### Architecture Patterns

#### Monorepo Structure
```
apps/
  web/                    # SvelteKit web application
    src/
      routes/            # File-based routing
      lib/               # Shared utilities
      components/        # Reusable components
    static/              # Static assets
    package.json

  backend/               # .NET or Rust backend service
    src/
      api/               # API endpoints/controllers
      services/          # Business logic
      git/               # Git operations wrapper
      models/            # Domain models
    tests/               # Backend tests
    Program.cs / main.rs
    .csproj / Cargo.toml

packages/
  shared/                # Shared types and utilities
    types/               # TypeScript types
    git/                 # Git-related models
    errors/              # Error handling
    package.json

  ui/                    # Reusable UI components
    components/          # shadcn/ui based components
    layouts/             # Layout components
    package.json

  domain-git/            # Git domain logic
    repository.ts        # Repository operations
    commit.ts            # Commit operations
    worktree.ts          # Worktree operations (core)
    branch.ts            # Branch operations
    merge.ts             # Merge operations

  domain-workflow/       # AI workflow domain
    agent-manager.ts     # AI agent worktree management
    sync-manager.ts      # Worktree synchronization
    review-manager.ts    # Code review workflow
```

#### Frontend Architecture

#### State Management
- Use **Svelte 5 Runes** (`$state`, `$derived`, `$effect`) for component state
- **Global state**: Svelte stores (`writable`, `readable`, `derived`) for app-wide state
- **Server state**: Use SvelteKit load functions and form actions for data fetching
- **Real-time updates**: WebSocket/SignalR connections for live Git status

#### Component Organization
- **Page components**: Route-specific pages in `src/routes/`
- **Feature components**: Grouped by domain (e.g., `git/commit-list/`, `git/worktree-panel/`)
- **UI components**: Reusable generic components in `packages/ui/`
- **Layout components**: Page layouts in `src/layouts/` or `routes/+layout.svelte`

#### Data Flow
- **Server → Client**: Server loads and real-time updates
- **Client → Server**: Form actions and API calls
- **Optimistic UI**: Update UI immediately, rollback on error
- **Error handling**: Display user-friendly errors, log technical details

#### Backend Architecture

#### API Layer (.NET)
- **Minimal API** or **Controllers** for endpoints
- **SignalR hubs** for real-time Git operations
- **Middleware**: Authentication, logging, error handling
- **Swagger/OpenAPI** for API documentation

#### API Layer (Rust)
- **Axum routers** for REST endpoints
- **Tokio channels** or WebSocket for real-time updates
- **Middleware layers** for auth, logging, compression
- **utoipa** or similar for OpenAPI documentation

#### Git Operations Layer
- **Abstraction**: Wrapper around Git library (LibGit2Sharp / gitoxide)
- **Repository-scoped operations**: All operations work on a specific repository path
- **Worktree isolation**: Each worktree is an independent Git working directory
- **Operation queue**: Queue Git operations to prevent conflicts
- **Event streaming**: Emit events for Git operations (commits, merges, conflicts)

#### Service Layer
- **Repository Service**: High-level Git operations (clone, status, commit, push, pull)
- **Worktree Service**: Worktree CRUD, status, synchronization
- **Branch Service**: Branch operations (create, checkout, merge, rebase)
- **Commit Service**: Commit history, diff, amend, cherry-pick
- **Merge Service**: Merge operations, conflict detection/resolution
- **Sync Service**: Synchronize worktree branches with remote or main

#### Separation of Concerns
- **Frontend**: Presentation layer, user interaction, state management
- **Backend**: Business logic, Git operations, API endpoints
- **Shared**: Types, models, validation logic
- **Git**: Native Git library operations wrapped in domain services

#### Key Features (Inspired by LazyGit)

#### Core Git Operations
- **Status**: View staged, unstaged, and untracked files
- **Files**: Stage/unstage individual files and hunks
- **Branches**: Create, checkout, rename, delete branches
- **Commits**: View commit history, commit graph, commit details
- **Stash**: Stash and pop changes
- **Tags**: Create, push, delete tags
- **Remotes**: Add, remove, fetch from remotes
- **Log**: View commit logs with filtering

#### Advanced Git Operations
- **Interactive Rebase**: Squash, fixup, edit, reorder, drop commits
- **Cherry-pick**: Apply commits from one branch to another
- **Bisect**: Find problematic commits
- **Amend**: Modify previous commits
- **Revert**: Revert commits
- **Reset**: Reset to specific commits (soft, mixed, hard)
- **Merge**: Merge branches with conflict resolution
- **Rebase**: Rebase branches onto another branch

#### Worktree Features (Primary Focus)
- **List Worktrees**: View all worktrees with their branches and status
- **Create Worktree**: Create worktree from branch or commit
- **Switch Worktree**: Switch focus between worktrees
- **Remove Worktree**: Remove worktree and prune
- **Worktree Status**: View status of each worktree independently
- **Sync Worktrees**: Synchronize worktree branches with each other
- **Compare Worktrees**: Diff changes between worktrees
- **Merge Worktree to Main**: One-click merge of worktree branch to main
- **AI Agent Isolation**: Each AI agent works in its own worktree

#### UI Features
- **Multi-panel Layout**: Similar to LazyGit (status, files, branches, commits, worktrees)
- **Command Palette**: Searchable command menu (Cmd/Ctrl+K)
- **Keyboard Navigation**: Full keyboard shortcuts for all operations
- **Commit Graph**: Visual representation of commit history
- **Diff View**: Inline, side-by-side, or unified diff view
- **Filtering**: Filter commits, branches, files by text
- **Real-time Updates**: Live updates of Git status via WebSocket/SignalR
- **Undo/Redo**: Undo/redo Git operations using reflog
- **Custom Commands**: Define and execute custom Git commands
- **Custom Pagers**: Use custom diff tools (diff-so-fancy, delta, etc.)
- **Theme**: Light/dark theme with customizable colors

#### Error Handling
- **User-friendly errors**: Show actionable messages, not technical details
- **Error recovery**: Suggest fixes for common errors (merge conflicts, detached HEAD)
- **Validation**: Validate inputs before sending to backend
- **Logging**: Log errors on both frontend and backend
- **Notification system**: Toast notifications for success/error states

### Testing Strategy

#### Frontend Testing (Vitest)
- Test all shared utilities and domain logic
- Test Svelte components with `@testing-library/svelte`
- Mock backend API calls with MSW (Mock Service Worker)
- Test user interactions and event handlers
- Aim for >80% coverage on business logic

#### Backend Testing
- Unit tests for all services and domain logic
- Integration tests for API endpoints
- Mock Git operations or use test repositories
- Test error handling and edge cases
- Aim for >80% coverage

#### E2E Testing (Playwright)
- Test complete workflows (clone, commit, push, pull)
- Test worktree creation and management
- Test merge and sync operations
- Test real-time updates and WebSocket connections
- Test keyboard navigation and accessibility

#### Testing Conventions
- **Test files**: `*.test.ts` or `*.spec.ts` next to source files
- **Test suites**: Use `describe` blocks to group related tests
- **Test naming**: `should [do something] when [condition]` format
- **Setup/teardown**: Use `beforeEach`/`afterEach` for test isolation

### Git Workflow

#### Branching Strategy
- **main**: Production-ready code, protected branch
- **develop**: Integration branch for features (optional)
- **feature/***: Feature development (e.g., `feature/add-worktree-sync`)
- **bugfix/***: Bug fixes (e.g., `bugfix/fix-merge-conflict`)
- **refactor/***: Code refactoring (e.g., `refactor/git-service-architecture`)
- **chore/***: Maintenance tasks (e.g., `chore/update-dependencies`)
- **docs/***: Documentation updates
- **test/***: Test additions or updates

#### Commit Conventions
Follow **Conventional Commits** format:
```
type(scope): description

[optional body]

[optional footer]
```

**Types:**
- `feat`: New feature
- `fix`: Bug fix
- `refactor`: Code refactoring (no behavior change)
- `perf`: Performance improvements
- `test`: Adding/updating tests
- `docs`: Documentation only
- `chore`: Maintenance (deps, build config, etc.)
- `style`: Code style (formatting, etc.)
- `ci`: CI/CD changes
- `build`: Build system changes

**Scopes:**
- `web`: Frontend web application
- `backend`: Backend service (.NET/Rust)
- `shared`: Shared package
- `ui`: UI components
- `domain-git`: Git domain logic
- `domain-workflow`: AI workflow domain
- `git-ops`: Git operations
- `worktrees`: Worktree management
- `ci`: CI/CD configuration

**Examples:**
```
feat(web): add worktree management panel
fix(backend): resolve race condition in git status operation
test(shared): add unit tests for worktree model
refactor(backend): migrate to async git operations
perf(web): optimize commit graph rendering
```

#### Pull Request Process
1. Create feature branch from main
2. Implement with tests
3. Run affected builds/tests: `nx affected:build`, `nx affected:test`, `nx affected:lint`
4. Create descriptive PR with:
   - Clear title following commit conventions
   - Description of changes
   - Link to related OpenSpec change
   - Screenshots for UI changes
   - Test coverage metrics
5. Request code review
6. Address feedback
7. Merge after approval and CI passes

#### Merge Strategy
- Use **squash merge** to keep main history clean
- Update PR description with final commit message before merging
- Delete feature branch after merge
- Maintain linear history on main

## Domain Context

### Git Repository Domain
- **Repository**: Represents a Git project with a root `.git` directory
- **Worktree**: Independent working directory sharing the same `.git` repository
  - Each worktree has its own branch checked out
  - Changes in one worktree don't affect others
  - Can switch between worktrees without stashing
- **Branch**: Refers to a branch within the repository or a worktree
- **Commit**: Individual revision with author, message, timestamp, and file changes
- **Remote**: Remote repository (GitHub, GitLab, Bitbucket)
- **Stash**: Saved changes that can be applied later

### Worktree Domain (Core)
- **Worktree Manager**: CRUD operations for worktrees
- **Worktree Status**: Independent status for each worktree
- **Worktree Synchronization**: Sync changes between worktrees
- **Worktree Merge**: Merge worktree branch to main or other branches
- **AI Agent Isolation**: Each AI agent operates in its own worktree

### AI Workflow Domain
- **AI Agent**: Autonomous code generation system (e.g., OpenCode)
- **Agent Instance**: Specific AI agent working in a worktree
- **Code Review**: Review AI-generated code before merging
- **Sync**: Synchronize AI agent branches with main or other agents
- **Conflict Resolution**: Resolve merge conflicts from AI changes

### Frontend Contexts
- **Dashboard**: Main view with worktree list and repository status
- **Files View**: View and stage files with diff visualization
- **Branches View**: Manage branches and worktrees
- **Commits View**: View commit history with graph
- **Stash View**: Manage stashed changes
- **Settings**: Configure application preferences

### Backend Contexts
- **API Layer**: REST endpoints for Git operations
- **Real-time Layer**: WebSocket/SignalR for live updates
- **Git Service**: High-level Git operations wrapper
- **Worktree Service**: Worktree-specific operations
- **Sync Service**: Synchronization logic between worktrees

### User Roles
- **Developer**: Primary user - works with AI agents to generate code
- **Maintainer**: Manages merges, reviews code, handles conflicts
- **AI Agent**: Automated system generating code in worktrees

## Important Constraints

### Technical Constraints
- **Local Git**: Backend must execute Git commands on local filesystem
- **Web Socket**: Real-time updates require persistent connections
- **Worktree Isolation**: Each worktree must be independent
- **Cross-platform**: Support Windows, macOS, Linux (for backend service)
- **Performance**: Handle large repositories (1000+ commits) efficiently
- **Concurrency**: Multiple AI agents working simultaneously in different worktrees

### Business Constraints
- **Privacy First**: No code is sent to external services (optional telemetry only)
- **Open Source**: Code should be publicly available (except for API keys if needed)
- **User Control**: Users control all Git operations
- **AI Integration**: Must integrate with external AI agents (OpenCode)
- **Speed**: Quick review and merge workflows for AI-generated code

### Regulatory Constraints
- **GDPR Compliance**: If storing user data (local storage), implement right to deletion/export
- **Security**: Validate all file paths and Git operations to prevent injection attacks
- **Access Control**: Backend service should run with appropriate permissions

### Platform Constraints
- **Browser Support**: Modern browsers (Chrome 90+, Firefox 88+, Safari 14+, Edge 90+)
- **Backend Dependencies**: Git must be installed on the system (or use embedded Git library)
- **Filesystem Access**: Backend needs read/write access to repositories
- **Network**: Local-only operation (no remote Git hosting required, but optional support)

## External Dependencies

### Git Libraries
- **LibGit2Sharp** (.NET) or **gitoxide** (Rust) - Git operations
- **Optional**: Native Git CLI execution for advanced features

### Web Frameworks
- **SvelteKit**: Frontend framework
- **shadcn/ui**: Component library
- **Radix UI**: Headless UI primitives
- **Tailwind CSS**: Styling

### Backend Frameworks
- **ASP.NET Core** (.NET) or **Axum/Actix** (Rust)
- **SignalR** (.NET) or **Tokio/WebSocket** (Rust) for real-time

### Development Tools
- **Nx CLI**: Workspace management, cache, affected commands
- **Vite**: Dev server, HMR, production builds
- **TypeScript**: Type checking and compilation
- **ESLint/Prettier/Biome**: Code quality and formatting
- **Vitest/Playwright/xUnit**: Testing frameworks

### External Git Services (Optional)
- **GitHub API**: For pull request creation/viewing
- **GitLab API**: For merge request creation/viewing
- **Bitbucket API**: For pull request creation/viewing
- **Generic Git**: Support for any Git remote

### AI Services
- **OpenCode**: AI agent for code generation (separate application)
- **OpenAI API**: Optional AI features (summarization, suggestions)

## Development Workflow Summary

1. **Planning Phase**:
   - Use OpenSpec to create change proposals
   - Write clear requirements and scenarios
   - Get approval before implementation

2. **Implementation Phase**:
   - Create Nx workspaces for new packages/features
   - Follow architecture patterns and conventions
   - Write tests as you code (TDD preferred)
   - Run `nx affected:*` commands frequently

3. **Quality Phase**:
   - Ensure all tests pass: `nx affected:test`
   - Check code quality: `nx affected:lint`
   - Build for production: `nx affected:build`
   - Manual testing of Git operations and worktree management

4. **Deployment Phase**:
   - Archive completed OpenSpec changes
   - Update specs if capabilities changed
   - Tag releases in Git
   - Build and package frontend and backend
   - Create installers for backend service (Windows MSI, macOS DMG, Linux DEB/RPM)

5. **Maintenance Phase**:
   - Monitor for issues and bug reports
   - Regular dependency updates
   - Performance audits
   - Documentation updates

## Key Differentiators from LazyGit

1. **Web-based GUI**: Modern web interface instead of TUI
2. **Worktree Focus**: Primary feature is worktree management, not secondary
3. **AI Agent Integration**: Designed for AI-assisted development workflows
4. **Real-time Collaboration**: WebSocket/SignalR for live updates
5. **Visual Diff Enhancements**: Better diff visualization than TUI
6. **Cross-platform UI**: Consistent experience across all platforms
7. **Command Palette**: Modern searchable command interface
8. **Keyboard-First**: Full keyboard navigation like LazyGit but with web UX

## MVP Features

### Phase 1: Core Git Operations
- [ ] Repository selection and status display
- [ ] File staging/unstaging (files and hunks)
- [ ] Commit creation with message editor
- [ ] Branch management (create, checkout, delete)
- [ ] Commit history view with graph
- [ ] Push/pull/fetch operations
- [ ] Basic diff view

### Phase 2: Worktree Management
- [ ] List worktrees with status
- [ ] Create worktree from branch
- [ ] Switch between worktrees
- [ ] Remove worktree
- [ ] Worktree-specific status display
- [ ] Basic worktree operations (commit, push, pull)

### Phase 3: AI Workflow Integration
- [ ] Quick review workflow for AI-generated code
- [ ] One-click merge of worktree branch to main
- [ ] Sync worktree branch with main
- [ ] Compare worktrees (diff between worktree branches)
- [ ] Batch operations (merge multiple worktrees to main)

### Phase 4: Advanced Features
- [ ] Interactive rebase UI
- [ ] Cherry-pick operations
- [ ] Stash management
- [ ] Tag management
- [ ] Remote management
- [ ] Custom commands
- [ ] Custom pagers/diff tools
- [ ] Real-time updates via WebSocket/SignalR
- [ ] Undo/redo with reflog
- [ ] Command palette
- [ ] Keyboard navigation
- [ ] Themes and customization

## Success Metrics

- **Performance**: <500ms to load repository status, <200ms for Git operations
- **UX**: Keyboard-first workflow, <3 clicks to perform any common operation
- **Stability**: <1% crash rate, handle large repositories (>10,000 commits)
- **Worktree Efficiency**: Switch between worktrees in <100ms
- **Test Coverage**: >80% coverage on critical paths
- **User Adoption**: Smooth onboarding for LazyGit users
