
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);// creating the kestrel webserver app that we need to run the website

builder.Services.AddControllersWithViews();// add contoller service that we need for MVC
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();// building the diff service with the webserver

app.UseStaticFiles();// Allow to read css,js, img files from www.root
if (app.Environment.IsDevelopment()) // show the dev tools when running app in DEV environment
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute(
    );//Enable to see the page from controller


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
DbInitializer.Seed(app);
app.Run();// launching app
