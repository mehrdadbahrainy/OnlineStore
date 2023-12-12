namespace OnlineStore.Entities.Entities;

public class Category : IBaseEntity, ISoftDeleteEnabledBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}