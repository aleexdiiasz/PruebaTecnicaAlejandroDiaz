using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiaz.Context;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class AlumnoProfesorModel
    {
        
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int ProfesorId { get; set; }

        public void Insert(AppDbContext dbContext)
        {
            dbContext.AlumnoProfesor.Add(this);
            dbContext.SaveChanges();
        }
    }

    public class AlumnoProfesorModel2
    {

        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public string? AlumnoNombre { get; set; }
        public int ProfesorId { get; set; }
        public string? ProfesorNombre { get; set; }

       
    }
}
