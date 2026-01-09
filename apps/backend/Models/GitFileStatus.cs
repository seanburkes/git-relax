namespace GitRelax.Backend.Models;

/// <summary>
/// Status of a file in git
/// </summary>
public enum GitFileStatus
{
    /// <summary>
    /// File has been added to staging area
    /// </summary>
    Added,
    
    /// <summary>
    /// File has been modified
    /// </summary>
    Modified,
    
    /// <summary>
    /// File has been deleted
    /// </summary>
    Deleted,
    
    /// <summary>
    /// File has been renamed
    /// </summary>
    Renamed,
    
    /// <summary>
    /// File is untracked (not in git)
    /// </summary>
    Untracked,
    
    /// <summary>
    /// File has been copied
    /// </summary>
    Copied
}
