using CupAPI.API;
using CupAPI.Application;
using CupAPI.Persistence;
using CupAPI.Persistence.Middlewares;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Layered Services
builder.Services.ApplicationServices();
builder.Services.PersistenceService(builder.Configuration);
builder.Services.PresentationService(builder.Configuration, builder.Host); // Controller, Jwt, Serilog and Authorization

// General
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

/**************************************************************/

var app = builder.Build();

// Scalar Docs
app.MapScalarApiReference(opt =>
{
    opt.Title = "Cup API v1";
    opt.Theme = ScalarTheme.Moon;
    opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
});

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SerilogMiddleware>();
app.MapControllers();
app.Run();