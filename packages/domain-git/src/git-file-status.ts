/**
 * Git file status enumeration
 */
export enum GitFileStatus {
  /** File has been added to the staging area */
  Added = 'Added',
  
  /** File has been modified */
  Modified = 'Modified',
  
  /** File has been deleted */
  Deleted = 'Deleted',
  
  /** File has been renamed */
  Renamed = 'Renamed',
  
  /** File is untracked (not in git) */
  Untracked = 'Untracked',
  
  /** File has been copied */
  Copied = 'Copied'
}
