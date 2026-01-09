namespace GitRelax.Backend.Models;

/// <summary>
/// Represents a file change in git
/// </summary>
public class GitFileChange
{
    /// <summary>
    /// File path relative to repository root
    /// </summary>
    public required string Path { get; set; }
    
    /// <summary>
    /// Status of the file
    /// </summary>
    public required GitFileStatus Status { get; set; }
    
    /// <summary>
    /// Whether the file is staged
    /// </summary>
    public required bool IsStaged { get; set; }
}
