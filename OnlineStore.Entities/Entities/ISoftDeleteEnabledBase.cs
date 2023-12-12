namespace OnlineStore.Entities.Entities;

public interface ISoftDeleteEnabledBase
{
    public bool IsDeleted { get; set; }
}