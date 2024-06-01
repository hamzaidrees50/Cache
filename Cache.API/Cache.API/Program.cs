using Cache.Service;
using Carter;
using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CacheDbContext>(o =>
	 o.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
	 , contextLifetime: ServiceLifetime.Singleton);
builder.Services.AddCarter();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddHostedService<CacheCleanupService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();