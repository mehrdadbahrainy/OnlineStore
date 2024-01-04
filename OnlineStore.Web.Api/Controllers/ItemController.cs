using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Entities;
using OnlineStore.Service;
using OnlineStore.Web.Api.Models;
using OnlineStore.Web.Api.Models.Category;
using OnlineStore.Web.Api.Models.Item;

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
    [AllowAnonymous]
    public async Task<IActionResult> GetItems([FromQuery] GetItemsRequest request)
    {
        var response = new ApiResponse<List<ItemResponse>>();

        var products = await _storeServices.ItemService.GetPagedAsync(
            x => true, request,
            true,
            x => x.Categories,
            x => x.MainCategory);

        response.Data = new List<ItemResponse>();
        response.Data.AddRange(products.Select(x => new ItemResponse(x)));

        return Ok(response);
    }

    [HttpGet("{itemId}/categiry")]
    [AllowAnonymous]
    public async Task<IActionResult> GetItemCategories([FromRoute] GetItemCategoriesRequest request)
    {
        var response = new ApiResponse<List<CategoryResponse>>();

        var itemCategories = await _storeServices.ItemCategoryService.GetAllAsync(
            x => x.ItemId == request.ItemId,
            true,
            x => x.Category);

        var categories = itemCategories.Select(x => x.Category);

        response.Data = new List<CategoryResponse>();
        response.Data.AddRange(categories.Select(x => new CategoryResponse(x)));

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
    {
        var response = new ApiResponse();

        var item = new Item()
        {
            Name = request.Name,
            EnName = request.EnName,
            CategoryId = request.CategoryId,
            Description = request.Description,
            Price = request.Price,
            ImageFile = request.ImageFile,
            IsActive = request.IsActive,
            UserId = UserId.Value,
            EntryDate = DateTime.UtcNow,
            IsDeleted = false,
        };

        _storeServices.ItemService.Add(item);
        await _storeServices.ItemService.SaveChangesAsync();

        return Ok(response);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditItem([FromBody] EditItemRequest request)
    {
        var response = new ApiResponse();

        var item = await _storeServices.ItemService.GetByIdAsync(request.Id);

        if (item == null)
        {
            return NotFound();
        }

        item.Name = request.Name;
        item.EnName = request.EnName;
        item.CategoryId = request.CategoryId;
        item.Description = request.Description;
        item.Price = request.Price;
        item.ImageFile = request.ImageFile;
        item.IsActive = request.IsActive;

        await _storeServices.ItemService.SaveChangesAsync();

        return Ok(response);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteItem([FromBody] DeleteItemRequest request)
    {
        var response = new ApiResponse();

        var item = await _storeServices.ItemService.GetByIdAsync(request.Id);

        if (item == null)
        {
            return NotFound();
        }

        _storeServices.ItemService.Delete(item);
        await _storeServices.ItemService.SaveChangesAsync();

        return Ok(response);
    }

    [HttpPost("categories")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddItemToCategories([FromBody] AddItemToCategoriesRequest request)
    {
        var response = new ApiResponse();

        var item = await _storeServices.ItemService.GetByIdAsync(request.ItemId);

        if (item == null)
        {
            return NotFound();
        }

        var categoryIds = request.CategoryIds.Distinct();
        var categories = await _storeServices.CategoryService.GetAllAsync(
            x => categoryIds.Contains(x.Id));

        foreach (var category in categories)
        {
            var itemCategoryExist = await _storeServices.ItemCategoryService.AnyAsync(x => x.ItemId == item.Id && x.CategoryId == category.Id);

            if (!itemCategoryExist)
            {
                var itemCategory = new ItemCategory()
                {
                    ItemId = item.Id,
                    CategoryId = category.Id,
                };

                _storeServices.ItemCategoryService.Add(itemCategory);
            }
        }

        await _storeServices.ItemCategoryService.SaveChangesAsync();

        return Ok(response);
    }
}