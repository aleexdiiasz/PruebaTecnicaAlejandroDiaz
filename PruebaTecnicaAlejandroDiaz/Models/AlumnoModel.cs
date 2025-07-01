using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiaz.Context;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class AlumnoModel
    {
        [Key]
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public void Insert(AppDbContext dbContext)
        {
            dbContext.Alumnos.Add(this);
            dbContext.SaveChanges();
        }
    }
}
