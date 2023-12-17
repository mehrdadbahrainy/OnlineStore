namespace OnlineStore.Web.Api.Models.Role;

public class AddRoleRequest : ApiRequest
{
    public string? Name { get; set; }
    public string? EnName { get; set; }
}