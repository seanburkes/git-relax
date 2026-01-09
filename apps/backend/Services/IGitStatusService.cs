using GitRelax.Backend.Models;

namespace GitRelax.Backend.Services;

/// <summary>
/// Interface for git status operations
/// </summary>
public interface IGitStatusService
{
    /// <summary>
    /// Get git status for a repository
    /// </summary>
    /// <param name="path">Path to the repository</param>
    /// <returns>Git status information</returns>
    Task<GitStatusResponse> GetStatusAsync(string path);
}
