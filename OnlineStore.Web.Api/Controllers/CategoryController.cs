﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities.Entities;
using OnlineStore.Service;
using OnlineStore.Web.Api.Models;
using OnlineStore.Web.Api.Models.Category;

namespace OnlineStore.Web.Api.Controllers;

[Route("api/category")]
public class CategoryController : BaseApiController
{
    private readonly StoreServices _storeServices;

    public CategoryController(StoreServices storeServices)
    {
        _storeServices = storeServices;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesRequest request)
    {
        var response = new ApiResponse<List<CategoryResponse>>();

        var products = await _storeServices.CategoryService.GetPagedAsync(
            x => true, request, true);

        response.Data = new List<CategoryResponse>();
        response.Data.AddRange(products.Select(x => new CategoryResponse(x)));

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var response = new ApiResponse();

        var category = new Category()
        {
            Name = request.Name,
            EnName = request.EnName,
            UserId = UserId.Value,
            EntryDate = DateTime.UtcNow,
            IsDeleted = false,
        };

        _storeServices.CategoryService.Add(category);
        await _storeServices.CategoryService.SaveChangesAsync();
        return Ok(response);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditCategory([FromBody] EditCategoryRequest request)
    {
        var response = new ApiResponse();

        var category = await _storeServices.CategoryService.GetByIdAsync(request.Id);

        if (category == null)
        {
            return NotFound();
        }

        category.Name = request.Name;
        category.EnName = request.EnName;

        await _storeServices.CategoryService.SaveChangesAsync();
        return Ok(response);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryRequest request)
    {
        var response = new ApiResponse();

        var category = await _storeServices.CategoryService.GetByIdAsync(request.Id);

        if (category == null)
        {
            return NotFound();
        }

        _storeServices.CategoryService.Delete(category);
        await _storeServices.CategoryService.SaveChangesAsync();
        return Ok(response);
    }
}