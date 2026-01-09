# Contributing to Git Relax

Thank you for your interest in contributing to git-relax! This document provides guidelines and instructions for contributing.

## Development Setup

1. **Fork and clone the repository**

   ```bash
   git clone https://github.com/your-username/git-relax.git
   cd git-relax
   ```

2. **Install dependencies**

   ```bash
   pnpm install
   pnpm run e2e:install  # Install Playwright browsers
   ```

3. **Start development servers**

   ```bash
   # Frontend
   nx serve web

   # Backend (in another terminal)
   nx serve backend
   ```

## Development Workflow

### Branch Strategy

- **main**: Production-ready code
- **develop**: Integration branch for features
- **feature/***: New features
- **bugfix/***: Bug fixes
- **hotfix/***: Urgent production fixes

### Creating a Feature

1. Create a branch from `develop`:
   ```bash
   git checkout develop
   git pull origin develop
   git checkout -b feature/your-feature-name
   ```

2. Make your changes following the coding standards.

3. Commit your changes with descriptive messages:
   ```bash
   git commit -m "feat: add user authentication"
   ```

4. Push and create a pull request:
   ```bash
   git push origin feature/your-feature-name
   ```

## Coding Standards

### Code Style

- **TypeScript**: Strict mode enabled, no `any` types
- **Svelte**: Use Svelte 5 Runes where applicable
- **Formatting**: 2 spaces, single quotes, semicolons required
- **Line length**: Maximum 100 characters

### Linting and Formatting

The project uses multiple linters and formatters:

- **ESLint**: JavaScript/TypeScript linting
- **Prettier**: Code formatting
- **Biome**: Fast optional linter/formatter
- **dotnet format**: .NET code formatting

Format your code before committing:

```bash
pnpm format        # Format with Biome
nx lint web       # Lint web app
nx lint backend   # Lint backend
```

### Pre-commit Hooks

Husky pre-commit hooks run linting automatically. To bypass (not recommended):

```bash
git commit --no-verify
```

## Testing

### Unit Tests

Run unit tests for the web app:

```bash
nx test web
```

With coverage:

```bash
nx test web --coverage
```

### E2E Tests

Run Playwright e2e tests:

```bash
nx e2e web
```

With UI mode:

```bash
pnpm run e2e:ui
```

### Test Requirements

- All new features must have unit tests
- Critical paths should have e2e tests
- Maintain test coverage above 80%

## Proposals and Changes

Use OpenSpec for larger changes:

1. Create a change proposal:
   ```bash
   openspec new
   ```

2. Define the change, tasks, and affected specs

3. Implement the change tasks

4. Archive when complete:
   ```bash
   openspec archive <change-id>
   ```

For more details, see `openspec/AGENTS.md`.

## UI Components

### Using shadcn/ui Components

Components are located in `apps/web/src/components/ui/`:

```svelte
<script lang="ts">
  import { Button } from '$components/ui';
</script>

<Button variant="default">Click me</Button>
```

### Adding New Components

```bash
npx shadcn@latest add [component-name]
```

See `apps/web/src/components/ui/README.md` for details.

## Documentation

### Code Comments

- Write clear, self-documenting code
- Add JSDoc comments for public APIs
- Explain complex algorithms or non-obvious logic

### Documentation Files

- Update READMEs when adding features
- Document new components in `components/ui/README.md`
- Keep NX_README.md updated with new commands

## Pull Request Guidelines

### PR Checklist

- [ ] Code follows project style guidelines
- [ ] Tests added/updated and passing
- [ ] Documentation updated
- [ ] Commit messages follow conventional commits
- [ ] No linting errors
- [ ] E2E tests pass (if applicable)

### PR Description

Include:

1. **Summary**: What changes and why
2. **Type**: Feature, bugfix, refactor, etc.
3. **Breaking changes**: Note any breaking changes
4. **Testing**: How you tested the changes
5. **Screenshots**: For UI changes

### Review Process

1. Maintainers will review your PR
2. Address review feedback
3. Update PR as needed
4. Approve and merge to `develop`

## Getting Help

- **Documentation**: Check `NX_README.md` and project READMEs
- **Issues**: Search existing issues or create a new one
- **Discussions**: Use GitHub Discussions for questions

## License

By contributing, you agree that your contributions will be licensed under the project's license.

---

Thank you for contributing to git-relax! 🎉
