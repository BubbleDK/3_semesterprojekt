using NetCafeUCN.MVC.Services;
using NetCafeUCN.MVC.Models;
using NetCafeUCN.MVC.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using NetCafeUCN.MVC.Models.DTO;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
string baseUri = "https://localhost:7197/api/";
// Add services to the container.
builder.Services.AddScoped<IUserProviderService, UserProviderService>(_ => new UserProviderService(baseUri + "User"));
builder.Services.AddScoped<INetCafeDataAccessService<GamingStationDto>, GamingstationService>( _ => new GamingstationService(baseUri + "GamingStation"));
builder.Services.AddScoped<INetCafeDataAccessService<BookingDto>, BookingService>(_ => new BookingService(baseUri + "Booking"));
builder.Services.AddScoped<BookingLineService>(_ => new BookingLineService(baseUri + "BookingLine"));
builder.Services.AddScoped<INetCafeDataAccessService<ConsumableDto>, ConsumableService>(_ => new ConsumableService(baseUri + "Consumable"));
builder.Services.AddScoped<INetCafeDataAccessService<CustomerDto>, CustomerService>(_ => new CustomerService(baseUri + "Customer"));
builder.Services.AddScoped<INetCafeDataAccessService<EmployeeDto>, EmployeeService>(_ => new EmployeeService(baseUri + "Employee"));
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
