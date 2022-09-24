using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Implementations;
using NavigationDomain.Repositories.Interfaces;
using NavigationModel.Configurations;
using NavigationModel.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<NavigationContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    ));

builder.Services.AddScoped<IRepository<Location>, LocationRepository>();
builder.Services.AddScoped<IRepository<Galaxy>, GalaxyRepository>();
builder.Services.AddScoped<IRepository<Planet>, PlanetRepository>();
builder.Services.AddScoped<IRepository<NavigationModel.Entities.Route>, RouteRepository>();

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