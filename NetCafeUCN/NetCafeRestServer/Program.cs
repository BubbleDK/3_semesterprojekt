using DataAccessLayer.DAO;
using DataAccessLayer.Model;
using NetCafeUCN.DAL.DAO;
using NetCafeUCN.DAL.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<INetCafeDataAccess<Booking>, BookingDataAccess>();
builder.Services.AddSingleton<INetCafeDataAccess<Person>, UserDataAccess>();
builder.Services.AddSingleton<INetCafeDataAccess<Product>, ProductDataAccess>();
builder.Services.AddSingleton<INetCafeDataAccess<GamingStation>, GamingStationDataAccess>();
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
