namespace GitRelax.Backend.Models;

/// <summary>
/// Standard error codes for API responses
/// </summary>
public static class ErrorCode
{
    /// <summary>
    /// Path parameter is missing
    /// </summary>
    public const string PathRequired = "PATH_REQUIRED";
    
    /// <summary>
    /// Invalid path provided
    /// </summary>
    public const string InvalidPath = "INVALID_PATH";
    
    /// <summary>
    /// Directory does not exist
    /// </summary>
    public const string DirectoryNotFound = "DIRECTORY_NOT_FOUND";
    
    /// <summary>
    /// Directory is not a git repository
    /// </summary>
    public const string NotGitRepository = "NOT_GIT_REPOSITORY";
    
    /// <summary>
    /// Permission denied accessing directory
    /// </summary>
    public const string PermissionDenied = "PERMISSION_DENIED";
    
    /// <summary>
    /// Unexpected internal error
    /// </summary>
    public const string InternalError = "INTERNAL_ERROR";
}
