namespace GitRelax.Backend.Models;

/// <summary>
/// Request model for getting git status of a repository
/// </summary>
public class GitStatusRequest
{
    /// <summary>
    /// The file system path to the git repository
    /// </summary>
    public required string Path { get; set; }
}
