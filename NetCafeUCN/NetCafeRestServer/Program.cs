using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<INetCafeDAO<Booking>, BookingDAO>();
builder.Services.AddScoped<INetCafeDAO<Customer>, CustomerDAO>();
builder.Services.AddScoped<INetCafeDAO<Consumable>, ConsumableDAO>();
builder.Services.AddScoped<INetCafeDAO<GamingStation>, GamingStationDAO>();
builder.Services.AddScoped<INetCafeDAO<Employee>, EmployeeDAO>();
builder.Services.AddScoped<UserDAO, UserDAO>();
builder.Services.AddScoped<BookingLineDAO, BookingLineDAO>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
