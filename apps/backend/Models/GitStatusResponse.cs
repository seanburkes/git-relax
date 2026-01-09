namespace GitRelax.Backend.Models;

/// <summary>
/// Response model for git status
/// </summary>
public class GitStatusResponse
{
    /// <summary>
    /// Current branch name
    /// </summary>
    public required string Branch { get; set; }
    
    /// <summary>
    /// Latest commit hash
    /// </summary>
    public required string CommitHash { get; set; }
    
    /// <summary>
    /// Latest commit message
    /// </summary>
    public required string CommitMessage { get; set; }
    
    /// <summary>
    /// Staged files
    /// </summary>
    public required List<GitFileChange> StagedFiles { get; set; } = new();
    
    /// <summary>
    /// Unstaged files
    /// </summary>
    public required List<GitFileChange> UnstagedFiles { get; set; } = new();
    
    /// <summary>
    /// Untracked files
    /// </summary>
    public required List<GitFileChange> UntrackedFiles { get; set; } = new();
}
