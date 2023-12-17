namespace OnlineStore.Entities.Entities;

public class Role : IBaseEntity, ISoftDeleteEnabled
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsDeleted { get; set; }
}