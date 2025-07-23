namespace Web.Responses;

public class ApiResponse<T>
{
    public T? Body { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }

    public static ApiResponse<T> Success(T data, string message = "Success", int statusCode = 200)
    {
        return new ApiResponse<T> { Body = data, Message = message, StatusCode = statusCode };
    }

    public static ApiResponse<T> Fail(string message, int statusCode = 500)
    {
        return new ApiResponse<T> { Body = default, Message = message, StatusCode = statusCode };
    }
}
