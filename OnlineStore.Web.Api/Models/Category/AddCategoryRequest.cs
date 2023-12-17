namespace OnlineStore.Web.Api.Models.Category;

public class AddCategoryRequest : ApiRequest
{
    public string? Name { get; set; }
    public string? EnName { get; set; }
}