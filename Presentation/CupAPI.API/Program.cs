using CupAPI.API.Extensions;
using CupAPI.Application;
using CupAPI.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Layered Services
builder.Services.ApplicationServices();
builder.Services.PersistenceService(builder.Configuration);

// JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// General Services
builder.Services.AddControllers();
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
app.MapControllers();
app.Run();