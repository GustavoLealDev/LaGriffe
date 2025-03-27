using Microsoft.EntityFrameworkCore;
using LaGrife.Models.Entities;
using LaGrife.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LaGrifeContext>(options =>
    options.UseMySql(
    builder.Configuration.GetConnectionString("LaGrifeContext"),
    new MySqlServerVersion(new Version(8, 0, 3)),
    mysqlOptions => mysqlOptions.MigrationsAssembly("LaGrife")
));

builder.Services.AddScoped<SeedingService>();

builder.Services.AddScoped<VendedorService>();

builder.Services.AddScoped<LojasService>();

builder.Services.AddScoped<VendaService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ptBR = new CultureInfo("pt-BR");
    var localizacao = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture(ptBR),
        SupportedCultures = new List<CultureInfo> { ptBR },
        SupportedUICultures = new List<CultureInfo> { ptBR }
    };

    app.UseRequestLocalization(localizacao);
    
    var services = scope.ServiceProvider;
    try
    {
        var seedingService = services.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao semear o banco de dados.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();