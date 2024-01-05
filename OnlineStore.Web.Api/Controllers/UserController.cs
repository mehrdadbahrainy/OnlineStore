using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Entities;
using OnlineStore.Service;
using OnlineStore.Web.Api.Models;
using OnlineStore.Web.Api.Models.user;
using OnlineStore.Web.Api.Models.User;
using OnlineStore.Web.Api.Security;

namespace OnlineStore.Web.Api.Controllers
{
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        private readonly Authentication _authentication;
        private readonly StoreServices _storeServices;

        public UserController(Authentication authentication,
            StoreServices storeServices)
        {
            _authentication = authentication;
            _storeServices = storeServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            var response = new ApiResponse<List<UserResponse>>();

            var users = await _storeServices.UserService.GetPagedAsync(request, true);
            var userResponse = new List<UserResponse>();
            userResponse.AddRange(users.Select(x => new UserResponse(x)));

            response.Data = userResponse;
            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = new ApiResponse<LoginResponse>();

            var user = await _storeServices.UserService.GetSingleAsync(
                x => x.Username == request.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var password = Utils.Encryption.GetMd5Hash($"{request.Password}_{user.PasswordSalt}");

            if (password.Equals(user.Password))
            {
                var userRoles = await _storeServices.UserRoleService.GetAllAsync(
                    x => x.UserId == user.Id);

                var roles = await _storeServices.RoleService.GetAllAsync(
                    x => userRoles.Select(ur => ur.RoleId).Contains(x.Id));

                var token = _authentication.GenerateJwtAuthentication(
                    user.Id,
                    user.Username!,
                    roles.Select(x => x.EnName));


                LoginResponse loginResponse = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = token,
                };

                response.Data = loginResponse;
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var user = await _storeServices.UserService.GetSingleAsync(
                x => x.Username == request.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var password = Utils.Encryption.GetMd5Hash($"{request.OldPassword}_{user.PasswordSalt}");

            if (password.Equals(user.Password))
            {

                var passwordSalt = Guid.NewGuid().ToString();
                password = Utils.Encryption.GetMd5Hash($"{request.NewPassword}_{passwordSalt}");

                user.PasswordSalt = passwordSalt;
                user.Password = password;

                _storeServices.UserService.Edit(user);
                await _storeServices.UserService.SaveChangesAsync();

                return Ok();
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var passwordSalt = Guid.NewGuid().ToString();
            var password = Utils.Encryption.GetMd5Hash($"{request.Password}_{passwordSalt}");

            var user = new User()
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                Password = password,
                PasswordSalt = passwordSalt,
                IsActive = true,
                EntryDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            _storeServices.UserService.Add(user);
            await _storeServices.UserService.SaveChangesAsync();

            return Ok();
        }
    }
}
