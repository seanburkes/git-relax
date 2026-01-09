namespace GitRelax.Backend.Models;

/// <summary>
/// Standard error response for all API endpoints
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Human-readable error message
    /// </summary>
    public required string Error { get; set; }
    
    /// <summary>
    /// Machine-readable error code
    /// </summary>
    public required string Code { get; set; }
    
    /// <summary>
    /// The path that caused the error (if applicable)
    /// </summary>
    public string? Path { get; set; }
}
