using CupAPI.Application.Interfaces;
using CupAPI.Application.Mappings;
using CupAPI.Application.Services.Abstract;
using CupAPI.Application.Services.Concrete;
using CupAPI.Persistence.Context;
using CupAPI.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

builder.Services.AddAutoMapper(typeof(GeneralMapping));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

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
