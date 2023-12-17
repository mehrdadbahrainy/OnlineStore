namespace OnlineStore.Web.Api.Models.Role;

public class AddUserRoleRequest : ApiRequest
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}