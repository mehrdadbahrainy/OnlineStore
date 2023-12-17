namespace OnlineStore.Web.Api.Models.Item;

public class EditItemRequest : ApiRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageFile { get; set; }
    public bool IsActive { get; set; }
}