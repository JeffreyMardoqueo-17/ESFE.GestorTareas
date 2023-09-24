using Microsoft.EntityFrameworkCore;
using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.BL.Service;
using ESFE.GestorTareas.UI.Controllers;
using AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GestorTareasBdContext>(opciones =>{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenSQL"));
});

//builder.Services.AddScoped<IGenericRepository<Categorium>, CategoriumRepository>();
//builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IGenericRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registron}/{action=Registro}/{id?}");
app.Run();