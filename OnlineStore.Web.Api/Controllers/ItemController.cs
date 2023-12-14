using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Service;
using OnlineStore.Web.Api.Models;
using OnlineStore.Web.Api.Models.Item;
using Serilog;

namespace OnlineStore.Web.Api.Controllers;

[Route("api/item")]
public class ItemController : BaseApiController
{
    private readonly StoreServices _storeServices;

    public ItemController(StoreServices storeServices)
    {
        _storeServices = storeServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems([FromQuery] GetItemsRequest request)
    {
        var response = new ApiResponse<List<ItemResponse>>();

        try
        {
            var products = await _storeServices.ItemService.GetPagedAsync(
                x => true, request, true);

            response.Data = new List<ItemResponse>();
            response.Data.AddRange(products.Select(x => new ItemResponse(x)));

            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Log.Error(ex, "Unhandled Exception");
            return StatusCode(500, response);
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
    {
        var response = new ApiResponse();

        try
        {
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Log.Error(ex, "Unhandled Exception");
            return StatusCode(500, response);
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}