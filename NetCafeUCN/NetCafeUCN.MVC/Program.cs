using NetCafeUCN.MVC.Services;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using NetCafeUCN.MVC.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserProviderService, UserProviderService>(_ => new UserProviderService("https://localhost:7197/api/User"));
builder.Services.AddScoped<INetCafeDataAccessService<GamingStationDto>, GamingstationService>( _ => new GamingstationService("https://localhost:7197/api/GamingStation"));
builder.Services.AddScoped<INetCafeDataAccessService<BookingDto>, BookingService>(_ => new BookingService("https://localhost:7197/api/Booking"));
builder.Services.AddScoped<BookingLineService>(_ => new BookingLineService("https://localhost:7197/api/BookingLine"));
builder.Services.AddScoped<INetCafeDataAccessService<ConsumableDto>, ConsumableService>(_ => new ConsumableService("https://localhost:7197/api/Consumable"));
builder.Services.AddScoped<INetCafeDataAccessService<CustomerDto>, CustomerService>(_ => new CustomerService("https://localhost:7197/api/Customer"));
builder.Services.AddScoped<INetCafeDataAccessService<EmployeeDto>, EmployeeService>(_ => new EmployeeService("https://localhost:7197/api/Employee"));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
