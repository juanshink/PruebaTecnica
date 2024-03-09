using EvoltisPruebaTecnica.Data;
using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.Data.Repositories;
using EvoltisPruebaTecnica.IServices;
using EvoltisPruebaTecnica.Model.DTOs;
using EvoltisPruebaTecnica.Model;
using EvoltisPruebaTecnica.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EvoltisPruebaTecnica.Profiles;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///AutoMapper
///
builder.Services.AddAutoMapper(cfg =>
{
    
    cfg.AddProfile(new GenericProfile<Alumno, AlumnoDTO>());
    cfg.AddProfile(new GenericProfile<Materia, MateriaDTO>());
    cfg.AddProfile(new GenericProfile<Profesor, ProfesorDTO>());
    cfg.AddProfile(new GenericProfile<ProfesorMateria, ProfesorMateriaDTO>());
    cfg.AddProfile(new GenericProfile<AlumnoMateria, AlumnoMateriaDTO>());
    
}, AppDomain.CurrentDomain.GetAssemblies());

//// Fluent Validator
builder.Services.AddControllers()
        .AddFluentValidation(x =>
        {
            x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });


///// MySQLConecction
var mySqlConfiguration = builder.Configuration.GetConnectionString("MySqlConnection");

/// DbContext
builder.Services.AddDbContext<MyDbContext>(options => 
        options.UseMySql(mySqlConfiguration, ServerVersion.AutoDetect(mySqlConfiguration)));

/// Services
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IAlumnoMateriaService, AlumnoMateriaService>();
builder.Services.AddScoped<IProfesorMateriaService, ProfesorMateriaService>();


/// Repos
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
builder.Services.AddScoped<IAlumnoMateriaRepository, AlumnoMateriaRepository>();
builder.Services.AddScoped<IProfesorMateriaRepository, ProfesorMateriaRepository>();

builder.Services.AddDirectoryBrowser();
//builder.Services.AddStaticFiles();

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7152; // Puerto HTTPS configurado en launchSettings.json
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
    {
        context.Request.Path = "/index.html";
        await next();
    }
});

app.UseHttpsRedirection();


app.Run();
