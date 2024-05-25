using Fiorello.DAL;
using Fiorello.Services;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("default"))
);

#region AddScoped

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IInstagramService, InstagramService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ISurprizeService, SurprizeService>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<ISurprizeListService, SurprizeListService>();
builder.Services.AddScoped<ISliderInfosService, SliderInfosService>();
builder.Services.AddScoped<ISettingService, SettingService>();

#endregion

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
