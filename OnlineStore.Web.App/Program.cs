using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess;
using OnlineStore.Service;

var builder = WebApplication.CreateBuilder(args);
string _allowSpecificOrigins = "_allowSpecificOrigins";
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _allowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllersWithViews();

var contextOptions = new DbContextOptionsBuilder<StoreDataContext>()
    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
    .Options;

builder.Services.AddTransient<StoreDataContext>(context => new StoreDataContext(contextOptions));
builder.Services.AddServices();

var app = builder.Build();

app.Run();
