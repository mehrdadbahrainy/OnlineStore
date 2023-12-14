namespace OnlineStore.Web.Api.Models;

public class ApiResponse<T> : ApiRequest
{
    public T? Data { get; set; }

    public ApiResponse() : base()
    {
    }
}
public class ApiResponse
{
    public List<string> Errors { get; set; }

    public ApiResponse()
    {
        Errors = new List<string>();
    }
}