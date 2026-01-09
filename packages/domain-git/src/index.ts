/**
 * Git domain types and utilities for git-relax
 * This package contains shared types for git operations
 */

// Task 4.1: Create shared types in packages/domain-git/
// Task 4.2: Add TypeScript type definitions for frontend integration

export type { GitFileStatus } from './git-file-status.js';
export type { GitFileChange } from './git-file-change.js';
export type { GitStatusResponse } from './git-status-response.js';
export type { ErrorResponse } from './error-response.js';

// Task 4.3: Export types from domain-git package
// All types are now exported above for frontend integration
