using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Logic;
using static PruebaTecnicaAlejandroDiaz.Logic.VistaLogic;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(c => c.AddPolicy("corspolicy", build =>
//{
//    build.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
//}));

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddScoped<EscuelaLogic>();
builder.Services.AddScoped<AlumnosLogic>();
builder.Services.AddScoped<ProfesoresLogic>();
builder.Services.AddScoped<AlumnoProfesorLogic>();
builder.Services.AddScoped<AlumnoEscuelaLogic>();
builder.Services.AddScoped<VistaLogic>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Prueba Tecnica ADS",
        Version = "v1.0.0.0"
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
