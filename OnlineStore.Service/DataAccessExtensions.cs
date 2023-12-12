using Microsoft.Extensions.DependencyInjection;

namespace OnlineStore.Service;

public static class DataAccessExtensions
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<CategoryService>();
        service.AddScoped<ItemService>();
        service.AddScoped<OrderService>();
        service.AddScoped<UserService>();
    }
}