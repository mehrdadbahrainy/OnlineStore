namespace OnlineStore.Web.Api.Models.Category;

public class CategoryResponse
{
    public CategoryResponse(Entities.Entities.Category item)
    {
        Id = item.Id;
        Name = item.Name;
        EnName = item.EnName;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }

}