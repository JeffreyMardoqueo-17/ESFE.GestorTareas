using Microsoft.EntityFrameworkCore;
using ESFE.GestorTareas.DAL.DataContext;
using ESFE.GestorTareas.DAL.Repositories;
using ESFE.GestorTareas.EN;
using ESFE.GestorTareas.BL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GestorTareasBdContext>(opciones =>{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("MiConexionBD"));
});

builder.Services.AddScoped<IGenericRepository<Categorium>, CategoriumRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IGenericRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IGenericRepository<Prioridad>, PrioridadRepository>();
builder.Services.AddScoped<IPrioridadService, PrioridadService>();
builder.Services.AddScoped<IGenericRepository<EstadoTarea>, EstadoTareaRepository>();
builder.Services.AddScoped<IEstadoTareaService, EstadoTareaService>();
builder.Services.AddScoped<IGenericRepository<Cargo>, CargoRepository>();
builder.Services.AddScoped<ICargoService, CargoService>();



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
    pattern: "{controller=Prioridad}/{action=Prioridad}/{id?}");


app.Run();