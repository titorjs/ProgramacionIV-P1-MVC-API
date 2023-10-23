using ApiColegioPagos.Data;
using ApiColegioPagos.Models;
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

// Inicializar valores por defecto
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiColegioPagosDbContext>();
    Global global = await dbContext.Globals.FirstOrDefaultAsync(x => x.Glo_id == 1);
    Pension pension = await dbContext.Pensiones.FirstOrDefaultAsync(x => x.Pen_id == 1); ;

    if (global == null)
    {
        global = new Global
        {
            Glo_nombre = "Cuota",
            Glo_valor = 1
        };
        await dbContext.Globals.AddAsync(global);
        await dbContext.SaveChangesAsync();
    }

    if (pension == null)
    {
        pension = new Pension
        {
            Pen_nombre = "Inscripción",
            Pen_valor = 0
        };

        await dbContext.Pensiones.AddAsync(pension);
        await dbContext.SaveChangesAsync();
    }
}

app.Run();
