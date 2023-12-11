namespace OnlineStore.Entities.Entities;

public class Item : IBaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageFile { get; set; }
    public int UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}