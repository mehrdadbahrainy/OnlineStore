namespace OnlineStore.Web.Api.Models.User;

public class ResetPasswordRequest
{
    public string? Username { get; set; }
    public string? OldPassword { get; set; }
    public string? NewPassword { get; set; }
}