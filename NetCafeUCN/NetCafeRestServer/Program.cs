using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<INetCafeDAO<Booking>, BookingDAO>();
builder.Services.AddSingleton<INetCafeDAO<Customer>, CustomerDAO>();
builder.Services.AddSingleton<INetCafeDAO<Consumable>, ConsumableDAO>();
builder.Services.AddSingleton<INetCafeDAO<GamingStation>, GamingStationDAO>();
builder.Services.AddSingleton<INetCafeDAO<Employee>, EmployeeDAO>();
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
