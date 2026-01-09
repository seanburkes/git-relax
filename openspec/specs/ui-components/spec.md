# ui-components Specification

## Purpose
TBD - created by archiving change scaffold-frontend-svelte-shadcn. Update Purpose after archive.
## Requirements
### Requirement: shadcn/ui Component Library
The project SHALL provide a shared shadcn/ui component library in `packages/ui/`.

#### Scenario: UI package initialization
- **WHEN** the UI package is created
- **THEN** a new Nx package is created at `packages/ui/`
- **AND** shadcn/ui CLI is initialized
- **AND** `components.json` is configured for shadcn/ui
- **AND** the package can be imported by the web application

#### Scenario: Tailwind CSS configuration
- **WHEN** the UI package is configured
- **THEN** Tailwind CSS is configured
- **AND** PostCSS is configured with Tailwind plugin
- **AND** Tailwind config includes shadcn/ui theme
- **AND** CSS variables are defined for theme customization

#### Scenario: Radix UI primitives
- **WHEN** shadcn/ui is initialized
- **THEN** Radix UI primitives are installed
- **AND** components are built on accessible primitives
- **AND** ARIA attributes are properly configured

### Requirement: Base Component Installation
The UI package SHALL include a set of base shadcn/ui components.

#### Scenario: Base components installed
- **WHEN** the UI package is initialized
- **THEN** the following components are installed via shadcn/ui CLI:
  - Button
  - Card
  - Input
  - Label
  - Textarea
  - Select
  - Checkbox
  - Dialog
  - Dropdown Menu
  - Tabs
  - Toast
- **AND** each component is exported from `packages/ui/`

#### Scenario: Component structure
- **WHEN** components are installed
- **THEN** each component follows shadcn/ui structure:
  - Component file in `ui/` directory
  - Types defined in TypeScript
  - Props interface exported
  - Default values documented

### Requirement: Icon Library
The UI package SHALL use Lucide Icons for consistent iconography.

#### Scenario: Lucide Icons installed
- **WHEN** the UI package is configured
- **THEN** Lucide Icons is installed
- **AND** icons can be imported as Svelte components
- **AND** icon size and color are customizable via props
- **AND** commonly used icons are available

#### Scenario: Icon usage in components
- **WHEN** a developer uses icons
- **THEN** icons are imported from `lucide-svelte`
- **AND** icons are used as Svelte components
- **AND** icons support size, color, and stroke width props

### Requirement: Package Exports
The UI package SHALL export all components and utilities for easy consumption.

#### Scenario: Component exports
- **WHEN** the UI package is configured
- **THEN** all shadcn/ui components are exported from `index.ts`
- **AND** utility functions are exported
- **AND** types are exported
- **AND** consumers can import via `@git-relax/ui/component-name`

#### Scenario: TypeScript types
- **WHEN** a developer imports components
- **THEN** TypeScript types are inferred automatically
- **AND** component props are fully typed
- **AND** autocomplete works in IDEs

### Requirement: Component Customization
The UI package SHALL support component customization via Tailwind CSS and CSS variables.

#### Scenario: Theme customization
- **WHEN** a developer wants to customize the theme
- **THEN** Tailwind config can be extended
- **AND** CSS variables can be overridden
- **AND** component styles can be modified via classes
- **AND** default theme uses semantic color tokens

#### Scenario: Component variants
- **WHEN** a developer uses shadcn/ui components
- **THEN** components support variants (e.g., button variants: default, destructive, outline, ghost, link)
- **AND** sizes (e.g., button sizes: default, sm, lg, icon)
- **AND** variant props are documented

### Requirement: Accessibility
The UI package SHALL provide accessible components built on Radix UI primitives.

#### Scenario: Keyboard navigation
- **WHEN** a user interacts with components
- **THEN** all interactive components support keyboard navigation
- **AND** focus is managed correctly
- **AND** keyboard shortcuts follow conventions

#### Scenario: Screen reader support
- **WHEN** a screen reader is used
- **THEN** all components have appropriate ARIA labels
- **AND** roles are correctly assigned
- **AND** state changes are announced

#### Scenario: High contrast mode
- **WHEN** a user enables high contrast mode
- **THEN** components remain visible
- **AND** contrast ratios meet WCAG AA standards
- **AND** focus indicators are clear

### Requirement: Component Documentation
The UI package SHALL provide documentation for all exported components.

#### Scenario: Component README
- **WHEN** a developer views `packages/ui/`
- **THEN** README.md is present
- **AND** it documents all exported components
- **AND** usage examples are provided
- **AND** prop types are documented
- **AND** customization examples are included

#### Scenario: In-code documentation
- **WHEN** a developer inspects component code
- **THEN** each component has JSDoc comments
- **AND** prop interfaces are documented
- **AND** examples are provided in comments

