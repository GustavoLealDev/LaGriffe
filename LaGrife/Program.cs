using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LaGrife.Models;
using System.Configuration;
using LaGrife.Models.Entities;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LaGrifeContext>(options =>
    options.UseMySql(
    builder.Configuration.GetConnectionString("LaGrifeContext"),
    new MySqlServerVersion(new Version(8, 0, 3)),
    mysqlOptions => mysqlOptions.MigrationsAssembly("LaGrife")
));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
