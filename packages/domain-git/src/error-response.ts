/**
 * Standard error response for all API endpoints
 */
export interface ErrorResponse {
  /** Human-readable error message */
  error: string;
  
  /** Machine-readable error code */
  code: string;
  
  /** The path that caused the error (if applicable) */
  path?: string;
}
