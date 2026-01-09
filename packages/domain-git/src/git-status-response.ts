import type { GitFileChange } from './git-file-change.js';

/**
 * Response model for git status
 */
export interface GitStatusResponse {
  /** Current branch name */
  branch: string;
  
  /** Latest commit hash */
  commitHash: string;
  
  /** Latest commit message */
  commitMessage: string;
  
  /** Staged files */
  stagedFiles: GitFileChange[];
  
  /** Unstaged files */
  unstagedFiles: GitFileChange[];
  
  /** Untracked files */
  untrackedFiles: GitFileChange[];
}
