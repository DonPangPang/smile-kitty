using SmileKitty.Application;
using SmileKitty.AutoMapper;
using SmileKitty.EntityFrameworkCore;
using SmileKitty.EventBus.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkCore();
builder.Services.AddApplication();
builder.Services.AddSmileKittyEventBus(opts => { });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.InitDatabaseAsync();
app.UseAutoMapper();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
