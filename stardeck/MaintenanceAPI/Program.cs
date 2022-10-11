using MaintenanceDomain.Repositories.Implementations;
using MaintenanceDomain.Repositories.Interfaces;
using MaintenanceModel.Configurations;
using MaintenanceModel.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<MaintenanceContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    ));

builder.Services.AddScoped<IRepository<ShipInfo>, ShipInfoRepository>();
builder.Services.AddScoped<IRepository<Inventory>, InventoryRepository>();
builder.Services.AddScoped<IRepository<Room>, RoomRepository>();
builder.Services.AddScoped<IRepository<MaintenanceModel.Entities.System>, SystemRepository>();
builder.Services.AddScoped<IRepository<EnergySystem>, EnergySystemRepository>();
builder.Services.AddScoped<IRepository<LifeSupportSystem>, LifeSupportSystemRepository>();
builder.Services.AddScoped<IRepository<GravitationSystem>, GravitationSystemRepository>();

TypeAdapterConfig.GlobalSettings.Default.MaxDepth(2).PreserveReference(true);

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();