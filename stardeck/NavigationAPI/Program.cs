using EventBusConnection;
using EventBusConnection.Client;
using EventBusConnection.Event;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NavigationDomain.Repositories.Implementations;
using NavigationDomain.Repositories.Interfaces;
using NavigationEvent;
using NavigationModel.Configurations;
using NavigationModel.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// lazy loading

builder.Services.AddDbContextFactory<NavigationContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    ));

builder.Services.AddScoped<IRepository<Location>, LocationRepository>();
builder.Services.AddScoped<IRepository<NavigationModel.Entities.Route>, RouteRepository>();
builder.Services.AddScoped<IRepository<Planet>, PlanetRepository>();
builder.Services.AddScoped<IRepository<Galaxy>, GalaxyRepository>();

builder.Services.AddSingleton<IEventPublisher, EventPublisher>();
builder.Services.AddSingleton<IEventProcessor, NavigationEventProcessor>();
builder.Services.AddHostedService<EventSubscriber>();


TypeAdapterConfig.GlobalSettings.Default.MaxDepth(2).PreserveReference(true);

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
;
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