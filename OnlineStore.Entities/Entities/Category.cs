namespace OnlineStore.Entities.Entities;

public class Category : IBaseEntity, ISoftDeleteEnabled
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }
    public int UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Item> MainItems { get; set; }
    public ICollection<Item> Items { get; set; }
}