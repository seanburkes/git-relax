import type { GitFileStatus } from './git-file-status.js';

/**
 * Represents a file change in git
 */
export interface GitFileChange {
  /** File path relative to repository root */
  path: string;

  /** Status of the file */
  status: GitFileStatus;

  /** Whether the file is staged */
  isStaged: boolean;
}
