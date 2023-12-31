using Api_Full06.Data;
using Api_Full06.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Conex�o com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("ApiFullConnection");
builder.Services.AddDbContext<Api_Full06.Data.AppContext>(opts =>
opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o AutoMapper
builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Valida a exist�ncia de um Migrate, caso contr�rio, ir� atualizar o Database
using (IServiceScope serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<Api_Full06.Data.AppContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
