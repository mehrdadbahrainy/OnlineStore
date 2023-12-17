namespace OnlineStore.Entities.Entities;

public class UserRole : IBaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}