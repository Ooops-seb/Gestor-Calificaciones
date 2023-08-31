using Microsoft.EntityFrameworkCore;
using escolastico.Models;
using escolastico.Services.Contract;
using escolastico.Services.Implementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PrjEscolasticoContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQL"));
});

builder.Services.AddScoped<ITitulacionService, TitulacionService>();
builder.Services.AddScoped<ICampusService, CampusService>();
builder.Services.AddScoped<IUsuarioService,UsuarioService>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IAsignaturaService, AsignaturaService>();
builder.Services.AddScoped<IAuditoriaService, AuditoriaService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<IParaleloService, ParaleloService>();
builder.Services.AddScoped<IActaService, ActaService>();
builder.Services.AddScoped<ICalificacionesService, CalificacionesService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add
    (
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        }
    );
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();