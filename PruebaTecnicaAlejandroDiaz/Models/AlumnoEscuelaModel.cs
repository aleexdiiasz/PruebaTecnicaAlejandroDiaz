using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiaz.Context;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class AlumnoEscuelaModel
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int EscuelaId { get; set; }
        public void Insert(AppDbContext dbContext)
        {
            dbContext.AlumnoEscuela.Add(this);
            dbContext.SaveChanges();
        }
    }

    public class AlumnoEscuelaModel2
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public string? AlumnoNombre { get; set; }
        public int EscuelaId { get; set; }
        public string? EscuelaNombre { get; set; }


    }


}
