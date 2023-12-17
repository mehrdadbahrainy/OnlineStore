namespace OnlineStore.Web.Api.Models.Category;

public class EditCategoryRequest : ApiRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }
}