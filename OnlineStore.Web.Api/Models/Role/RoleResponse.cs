namespace OnlineStore.Web.Api.Models.Role;

public class RoleResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }
    public DateTime EntryDate { get; set; }

    public RoleResponse(Entities.Entities.Role role)
    {
        Id = role.Id;
        Name = role.Name;
        EnName = role.EnName;
        EntryDate = role.EntryDate;
    }
}