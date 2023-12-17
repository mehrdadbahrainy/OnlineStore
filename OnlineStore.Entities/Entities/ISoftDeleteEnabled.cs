namespace OnlineStore.Entities.Entities;

public interface ISoftDeleteEnabled
{
    public bool IsDeleted { get; set; }
}