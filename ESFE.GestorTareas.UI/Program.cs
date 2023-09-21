using Microsoft.EntityFrameworkCore;
using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.BL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GestorTareasBdContext>(opciones =>{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenSQL"));
});

builder.Services.AddScoped<IGenericRepository<Categorium>, CategoriumRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();