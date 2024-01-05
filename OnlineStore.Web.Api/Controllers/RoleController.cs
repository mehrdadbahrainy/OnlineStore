using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Entities;
using OnlineStore.Service;
using OnlineStore.Web.Api.Models.User;
using OnlineStore.Web.Api.Models;
using OnlineStore.Web.Api.Models.Role;

namespace OnlineStore.Web.Api.Controllers;

[Route("api/role")]
[Authorize(Roles = "Admin")]
public class RoleController : BaseApiController
{
    private readonly StoreServices _storeServices;

    public RoleController(StoreServices storeServices)
    {
        _storeServices = storeServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles([FromQuery] GetRolesRequest request)
    {
        var response = new ApiResponse<List<RoleResponse>>();

        var roles = await _storeServices.RoleService.GetPagedAsync(request, true);
        var rolesResponse = new List<RoleResponse>();
        rolesResponse.AddRange(roles.Select(x => new RoleResponse(x)));

        response.Data = rolesResponse;
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request)
    {
        var response = new ApiResponse();

        var role = new Role()
        {
            Name = request.Name,
            EnName = request.EnName,
            EntryDate = DateTime.UtcNow,
            IsDeleted = false,
        };

        _storeServices.RoleService.Add(role);
        var inserted = await _storeServices.RoleService.SaveChangesAsync();

        if (inserted > 0)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> EditRole([FromBody] EditRoleRequest request)
    {
        var response = new ApiResponse();

        var role = await _storeServices.RoleService.GetByIdAsync(request.Id);

        if (role == null)
        {
            return NotFound();
        }

        role.Name = request.Name;
        role.EnName = request.EnName;

        var updated = await _storeServices.RoleService.SaveChangesAsync();

        if (updated > 0)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleRequest request)
    {
        var response = new ApiResponse<LoginResponse>();

        var role = await _storeServices.RoleService.GetByIdAsync(request.Id, true);

        if (role == null)
        {
            return NotFound();
        }

        _storeServices.RoleService.Delete(role);
        await _storeServices.RoleService.SaveChangesAsync();

        return Ok(response);
    }

    [HttpPost("user-role")]
    public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleRequest request)
    {
        var response = new ApiResponse();

        var isExisted = await _storeServices.UserRoleService.AnyAsync(
            x => x.UserId == request.UserId &&
                x.RoleId == request.RoleId);

        if (isExisted)
        {
            return BadRequest();
        }

        var userRole = new UserRole
        {
            RoleId = request.RoleId,
            UserId = request.UserId,
        };

        _storeServices.UserRoleService.Add(userRole);
        await _storeServices.UserRoleService.SaveChangesAsync();

        return Ok(response);
    }

    [HttpDelete("user-role")]
    public async Task<IActionResult> DeleteUserRole([FromQuery] DeleteUserRoleRequest request)
    {
        var response = new ApiResponse();

        var userRole = await _storeServices.UserRoleService.GetSingleAsync(
            x => x.UserId == request.UserId &&
                x.RoleId == request.RoleId);

        if (userRole == null)
        {
            return BadRequest();
        }

        _storeServices.UserRoleService.Delete(userRole);
        await _storeServices.UserRoleService.SaveChangesAsync();

        return Ok(response);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> AddUserRole([FromRoute] int userId)
    {
        var response = new ApiResponse<List<RoleResponse>>();

        var userRoles = await _storeServices.UserRoleService.GetAllAsync(
            x => x.UserId == userId);

        var roles = await _storeServices.RoleService.GetAllAsync(
            x => userRoles.Select(ur => ur.RoleId).Contains(x.Id)
            , true);

        var rolesResponse = new List<RoleResponse>();
        rolesResponse.AddRange(roles.Select(x => new RoleResponse(x)));

        response.Data = rolesResponse;
        return Ok(response);
    }

}