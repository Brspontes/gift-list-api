using BrsPontes.GiftList.API.Application.Configurations;
using BrsPontes.GiftList.API.Application.Services;
using BrsPontes.GiftList.API.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<GiftDatabaseSettings>(
    builder.Configuration.GetSection("GiftDatabase"));

builder.Services.AddScoped<IGiftItemService, GiftItemService>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();

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
