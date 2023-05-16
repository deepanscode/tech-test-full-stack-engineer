using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TradieApp.Api.Filters;
using TradieApp.Application;
using TradieApp.Infrastructure;
using TradieApp.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Adding API version
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

// Add services to the container.
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);

// TODO: Add the presentation assembly
var presentationAssembly = typeof(TradieApp.Presentation.Controllers.V1.JobsController).Assembly;
builder.Services.AddControllers()
    .AddApplicationPart(presentationAssembly).AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.OperationFilter<RemoveVersionParameterFilter>();
    options.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins",
        policy  =>
        {
            var allowedOrigins = builder.Configuration["AllowedOrigins"];
            if (!string.IsNullOrEmpty(allowedOrigins))
            {
                policy.WithOrigins(allowedOrigins.Split(","))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("X-Pagination");
            }
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("AllowedOrigins");

app.MapControllers();

app.Run();
