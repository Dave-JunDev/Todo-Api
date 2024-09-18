using Context;
using Interfaces;
using Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DTO;
using Validators;
using Utils;

var builder = WebApplication.CreateBuilder(args);
// context
builder.Services.AddDbContext<PostgresContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

// Add services to the container.
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IPaginationUtil, PaginationUtil>();

// validators
builder.Services.AddScoped<IValidator<TodoDTO>, TodoValidators>();

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
