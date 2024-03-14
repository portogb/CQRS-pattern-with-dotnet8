using Cities.API.Filters;
using Cities.Application.Command.City.CreateCity;
using Cities.Infra.Data.Context;
using Cities.Infra.Ioc;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x => x
    .Filters
    .Add(typeof(ValidationFilter)))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateCityCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var connection = builder
    .Configuration
    .GetConnectionString("DefaultConnection");

builder
    .Services
    .AddDbContext<AppDbContext>(o => o
    .UseSqlServer(connection));

builder
    .Services
    .AddInfrastructure(configuration);

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
