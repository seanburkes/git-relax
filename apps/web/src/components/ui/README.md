# UI Components

This directory contains shadcn/ui components used throughout the application.

## Installation

The components are installed and configured using the shadcn/ui CLI. To add new components:

```bash
npx shadcn@latest add [component-name]
```

## Available Components

### Button

A customizable button component with variants and sizes.

**Usage:**

```svelte
<script lang="ts">
  import { Button } from '$components/ui';
</script>

<Button variant="default" size="md">Click me</Button>
```

**Variants:** `default`, `destructive`, `outline`, `secondary`, `ghost`, `link`
**Sizes:** `sm`, `md`, `lg`

## Component Structure

Each component follows this structure:

```
components/ui/
  ├── button/
  │   └── index.ts (internal exports)
  ├── Button.svelte
  ├── Button.test.ts
  └── index.ts (public exports)
```

## Styling

Components use Tailwind CSS with class variance authority (CVA) for variant management. Styles are defined in `components/ui/[component]/index.ts`.

## Testing

Each component has an associated test file using Vitest and @testing-library/svelte.

```bash
nx test web
```

## Customization

To customize a component:

1. Modify the component file (`Button.svelte`)
2. Update the variant definitions in the component's `index.ts`
3. Ensure tests still pass

## Documentation

For more information, see the [shadcn/ui documentation](https://ui.shadcn.com/).
