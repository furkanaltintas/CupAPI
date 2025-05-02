using CupAPI.Application;
using CupAPI.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ApplicationServices();
builder.Services.PersistenceService(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();



/**************************************************************/

var app = builder.Build();

app.MapScalarApiReference(opt =>
{
    opt.Title = "Cup API v1";
    opt.Theme = ScalarTheme.Moon;
    opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
