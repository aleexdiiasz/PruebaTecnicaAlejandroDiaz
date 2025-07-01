using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiaz.Context;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class ProfesorModel
    {
        [Key]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int EscuelaId { get; set; }

        public void Insert(AppDbContext context)
        {
            context.Profesores.Add(this);
            context.SaveChanges();
        }
    }
}
