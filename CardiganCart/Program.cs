using CardiganCart.DataAccess;
using CardiganCart.Interfaces;
using CardiganCart.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CardiganDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICardiganService, CardiganDataAccessLayer>();
builder.Services.AddTransient<IOrderService, OrderDataAccessLayer>();
builder.Services.AddTransient<ICartService, CartDataAccessLayer>();
builder.Services.AddTransient<IUserService, UserDataAccessLayer>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
