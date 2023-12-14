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
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageFile { get; set; }

}