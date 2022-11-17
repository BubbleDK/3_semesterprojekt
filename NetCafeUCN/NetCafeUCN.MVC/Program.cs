using NetCafeUCN.MVC.Services;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<INetCafeDataAccess<Product>, ProductService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<INetCafeDataAccess<Customer>, CustomerService>(_ => new CustomerService("https://localhost:7197/api/Customer"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
