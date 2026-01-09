using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GitRelax.Backend.Models;
using GitRelax.Backend.Services;

namespace GitRelax.Backend.Controllers;

/// <summary>
/// Controller for git operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class GitController : ControllerBase
{
    private readonly IGitStatusService _gitStatusService;
    private readonly ILogger<GitController> _logger;

    public GitController(IGitStatusService gitStatusService, ILogger<GitController> logger)
    {
        _gitStatusService = gitStatusService;
        _logger = logger;
    }

    /// <summary>
    /// Get git status for a repository
    /// </summary>
    /// <param name="path">Path to git repository</param>
    /// <returns>Git status information</returns>
    /// <response code="200">Returns git status successfully</response>
    /// <response code="400">Invalid request parameters</response>
    /// <response code="403">Permission denied</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("status")]
    [ProducesResponseType(typeof(GitStatusResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetStatus([FromQuery] string? path)
    {
        try
        {
            // Task 3.3: Add request validation (ensure path is provided)
            if (string.IsNullOrWhiteSpace(path))
            {
                _logger.LogWarning("Git status requested without path parameter");
                return BadRequest(new ErrorResponse
                {
                    Error = "Path parameter is required",
                    Code = ErrorCode.PathRequired
                });
            }

            _logger.LogInformation("Getting git status for: {Path}", path);
            var status = await _gitStatusService.GetStatusAsync(path);
            return Ok(status);
        }
        catch (ArgumentException ex)
        {
            // Handle validation errors
            _logger.LogWarning(ex, "Invalid path parameter: {Path}", path);
            return BadRequest(new ErrorResponse
            {
                Error = ex.Message,
                Code = ErrorCode.InvalidPath,
                Path = path
            });
        }
        catch (DirectoryNotFoundException ex)
        {
            // Task 2.6 error handling: Invalid directory path
            _logger.LogWarning(ex, "Directory not found: {Path}", path);
            return BadRequest(new ErrorResponse
            {
                Error = $"Directory not found: {path}",
                Code = ErrorCode.DirectoryNotFound,
                Path = path
            });
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("git repository"))
        {
            // Task 2.6 error handling: Not a git repository
            _logger.LogWarning(ex, "Not a git repository: {Path}", path);
            return BadRequest(new ErrorResponse
            {
                Error = $"Not a git repository: {path}",
                Code = ErrorCode.NotGitRepository,
                Path = path
            });
        }
        catch (UnauthorizedAccessException ex)
        {
            // Task 2.6 error handling: Permission denied
            _logger.LogError(ex, "Permission denied: {Path}", path);
            return StatusCode(StatusCodes.Status403Forbidden, new ErrorResponse
            {
                Error = $"Permission denied: {path}",
                Code = ErrorCode.PermissionDenied,
                Path = path
            });
        }
        catch (Exception ex)
        {
            // Task 2.6 error handling: Unexpected errors
            _logger.LogError(ex, "Error getting git status for: {Path}", path);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
            {
                Error = "An error occurred while retrieving git status",
                Code = ErrorCode.InternalError
            });
        }
    }
}
