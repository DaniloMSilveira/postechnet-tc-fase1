using FCG.Domain.Interfaces.Repositories;
using FCG.Domain.Interfaces.Services;
using FCG.Domain.Services;
using FCG.Infrastructure.Contexts;
using FCG.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("FCG") ?? throw new InvalidOperationException("Connection string 'FCG' not found.");
builder.Services.AddDbContext<FCGContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FCG")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllers();

var connStr = builder.Configuration.GetConnectionString("FCG");
Console.WriteLine($"String de conexão: {connStr}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
