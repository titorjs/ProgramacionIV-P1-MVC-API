using ApiColegioPagos.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ApiColegioPagosDbContext>();

// Contexto de la base de datos
builder.Services.AddDbContext<ApiColegioPagosDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConstStr")));


var app = builder.Build();

// Configure the HTTP request pipeline.z
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
