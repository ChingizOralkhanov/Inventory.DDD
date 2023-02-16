using Inventory.API.Products.Queries;
using Inventory.Domain.Entities;
using Inventory.Domain.Primitives;
using Inventory.Infrastructure.DataAccess.Repositories;
using Inventory.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(configuration);
builder.Services.ConfigureMediatR();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory V1"));
}

app.UseExceptionHandler(a => a.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exception = exceptionHandlerPathFeature.Error;
    await context.Response.WriteAsJsonAsync(new { error = exception.Message });
}));
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
