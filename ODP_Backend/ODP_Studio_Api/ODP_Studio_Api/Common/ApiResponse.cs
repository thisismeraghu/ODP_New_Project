namespace ODP_Studio_Api.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }                // Operation outcome
        public int StatusCode { get; set; }              // HTTP Status code
        public string? Message { get; set; }             // Informational message
        public T? Data { get; set; }                      // Payload data (generic)
        public List<string>? Errors { get; set; }        // List of error messages

        // Optional: Pagination metadata for paged responses
        public PaginationMetadata? Pagination { get; set; }

        // Optional: Additional metadata dictionary for extra info
        public Dictionary<string, object?>? Meta { get; set; }

        // Timestamp to indicate when the response was generated (UTC)
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ApiResponse() { }

        // Success response constructor
        public ApiResponse(T data, string? message = null, int statusCode = 200)
        {
            Success = true;
            StatusCode = statusCode;
            Message = message ?? "Request succeeded.";
            Data = data;
        }

        // Failure response constructor
        public ApiResponse(string message, int statusCode = 400, List<string>? errors = null)
        {
            Success = false;
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }

        // Static helper for paged success response
        public static ApiResponse<T> SuccessPaged(T data, PaginationMetadata pagination, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>(data, message, statusCode)
            {
                Pagination = pagination
            };
        }
    }

    

}
