using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.RegularExpressions;
using GitRelax.Backend.Models;

namespace GitRelax.Backend.Services;

/// <summary>
/// Service for executing git status operations via CLI
/// </summary>
public class GitStatusService : IGitStatusService
{
    private readonly ILogger<GitStatusService> _logger;

    public GitStatusService(ILogger<GitStatusService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get git status for a repository
    /// </summary>
    public async Task<GitStatusResponse> GetStatusAsync(string path)
    {
        // Task 2.4: Add path validation (check if directory exists)
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Path parameter is required", nameof(path));
        }

        // Normalize and validate path
        var normalizedPath = Path.GetFullPath(path);
        
        if (!Directory.Exists(normalizedPath))
        {
            _logger.LogError("Directory not found: {Path}", normalizedPath);
            throw new DirectoryNotFoundException($"Directory not found: {normalizedPath}");
        }

        // Task 2.5: Add git repository validation (check if it's a valid git repo)
        var gitDir = Path.Combine(normalizedPath, ".git");
        if (!Directory.Exists(gitDir) && !File.Exists(gitDir))
        {
            _logger.LogError("Not a git repository: {Path}", normalizedPath);
            throw new InvalidOperationException($"Not a git repository: {normalizedPath}");
        }

        _logger.LogInformation("Getting git status for: {Path}", normalizedPath);

        // Task 2.6 & 2.7: Execute git command and handle errors
        return await ExecuteGitStatusAsync(normalizedPath);
    }

    /// <summary>
    /// Execute git status command and parse output
    /// </summary>
    private async Task<GitStatusResponse> ExecuteGitStatusAsync(string repoPath)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "git",
            Arguments = "status --porcelain=v2 --branch",
            WorkingDirectory = repoPath,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = startInfo };
        
        try
        {
            process.Start();
            
            var output = await process.StandardOutput.ReadToEndAsync();
            var error = await process.StandardError.ReadToEndAsync();
            
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                _logger.LogError("Git command failed with exit code {ExitCode}: {Error}", process.ExitCode, error);
                throw new InvalidOperationException($"Git command failed: {error}");
            }

            return ParseGitStatusOutput(output, repoPath);
        }
        catch (Exception ex) when (ex is not DirectoryNotFoundException)
        {
            _logger.LogError(ex, "Error executing git status");
            throw;
        }
    }

    /// <summary>
    /// Parse git status --porcelain=v2 output
    /// </summary>
    private GitStatusResponse ParseGitStatusOutput(string output, string repoPath)
    {
        var response = new GitStatusResponse
        {
            Branch = "(detached)",
            CommitHash = "unknown",
            CommitMessage = "unknown",
            StagedFiles = new(),
            UnstagedFiles = new(),
            UntrackedFiles = new()
        };

        var lines = output.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            // Parse branch info from first line
            if (line.StartsWith("# branch."))
            {
                if (line.StartsWith("# branch.head "))
                {
                    response.Branch = line.Substring("# branch.head ".Length);
                }
                continue;
            }

            // Parse file status
            if (line.Length >= 2 && line[0] != '#')
            {
                var statusCode = line[..2];
                var filePath = line[3..].Trim();

                var fileChange = new GitFileChange
                {
                    Path = filePath,
                    Status = ParseFileStatus(statusCode),
                    IsStaged = statusCode[0] != ' ' && statusCode[0] != '?'
                };

                // Task 2.6: Categorize files by status
                if (statusCode == "??")
                {
                    response.UntrackedFiles.Add(fileChange);
                }
                else if (statusCode[0] != ' ' && statusCode[1] == ' ')
                {
                    response.StagedFiles.Add(fileChange);
                }
                else if (statusCode[0] == ' ' && statusCode[1] != ' ')
                {
                    response.UnstagedFiles.Add(fileChange);
                }
                else if (statusCode[0] != ' ' && statusCode[1] != ' ')
                {
                    // File has both staged and unstaged changes
                    response.StagedFiles.Add(new GitFileChange
                    {
                        Path = filePath,
                        Status = ParseFileStatus(statusCode),
                        IsStaged = true
                    });
                    response.UnstagedFiles.Add(new GitFileChange
                    {
                        Path = filePath,
                        Status = ParseFileStatus(statusCode),
                        IsStaged = false
                    });
                }
            }
        }

        // Try to get current commit info
        try
        {
            var commitInfo = GetLatestCommit(repoPath);
            response.CommitHash = commitInfo.hash;
            response.CommitMessage = commitInfo.message;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not retrieve commit information");
        }

        return response;
    }

    /// <summary>
    /// Parse file status from porcelain status code
    /// </summary>
    private GitFileStatus ParseFileStatus(string statusCode)
    {
        var statusChar = statusCode[0] == ' ' ? statusCode[1] : statusCode[0];

        return statusChar switch
        {
            'M' => GitFileStatus.Modified,
            'A' => GitFileStatus.Added,
            'D' => GitFileStatus.Deleted,
            'R' => GitFileStatus.Renamed,
            'C' => GitFileStatus.Copied,
            _ => GitFileStatus.Modified
        };
    }

    /// <summary>
    /// Get latest commit hash and message
    /// </summary>
    private (string hash, string message) GetLatestCommit(string repoPath)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "git",
            Arguments = "log -1 --pretty=format:%H|%s",
            WorkingDirectory = repoPath,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = startInfo };
        process.Start();
        
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        var parts = output.Split('|');
        return parts.Length >= 2 ? (parts[0], parts[1]) : ("unknown", "unknown");
    }
}
