using ApiLayer.Middlewares;
using BusinessLogicLayer;
using BusinessLogicLayer.Mappers;
using DataAccessLayer;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLayer();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddAutoMapper(typeof(ProductMapping).Assembly);
builder.Services.AddAutoMapper(typeof(AddProductRequestMapping).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateProductRequestMapping).Assembly);
builder.Services.AddAutoMapper(typeof(DeleteProductRequestMapping).Assembly);


builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
