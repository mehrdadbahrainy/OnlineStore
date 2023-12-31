﻿using Microsoft.Extensions.DependencyInjection;

namespace OnlineStore.Service;

public static class DataAccessExtensions
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<CategoryService>();
        service.AddScoped<ItemService>();
        service.AddScoped<ItemCategoryService>();
        service.AddScoped<OrderService>();
        service.AddScoped<RoleService>();
        service.AddScoped<UserService>();
        service.AddScoped<UserRoleService>();

        service.AddScoped<StoreServices>();
    }
}