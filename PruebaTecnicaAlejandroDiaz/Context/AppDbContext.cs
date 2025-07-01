using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAlejandroDiaz.Models;


namespace PruebaTecnicaAlejandroDiaz.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EscuelaModel> Escuelas { get; set; }
    public DbSet<ProfesorModel> Profesores { get; set; }
    public DbSet<AlumnoModel> Alumnos { get; set; }
    public DbSet<AlumnoProfesorModel> AlumnoProfesor { get; set; }
    public DbSet<AlumnoEscuelaModel> AlumnoEscuela { get; set; }

}

