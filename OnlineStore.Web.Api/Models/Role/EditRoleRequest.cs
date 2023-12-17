namespace OnlineStore.Web.Api.Models.Role;

public class EditRoleRequest : ApiRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? EnName { get; set; }
}