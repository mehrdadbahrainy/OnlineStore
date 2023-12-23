using OnlineStore.Web.Api.Models.Category;

namespace OnlineStore.Web.Api.Models.Item;

public class ItemResponse
{
    public ItemResponse(Entities.Entities.Item item)
    {
        Id = item.Id;
        Name = item.Name;
        CategoryId = item.CategoryId;
        Description = item.Description;
        Price = item.Price;
        ImageFile = item.ImageFile;

        MainCategory = new CategoryResponse(item.MainCategory);

        Categories = new List<CategoryResponse>();
        if (item.Categories.Any())
        {
            Categories.AddRange(item.Categories.Select(x => new CategoryResponse(x)));
        }
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageFile { get; set; }
    public CategoryResponse MainCategory { get; set; }
    public List<CategoryResponse> Categories { get; set; }

}