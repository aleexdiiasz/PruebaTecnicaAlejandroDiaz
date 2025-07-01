using System.ComponentModel.DataAnnotations;
using PruebaTecnicaAlejandroDiaz.Context;

namespace PruebaTecnicaAlejandroDiaz.Models
{
    public class EscuelaModel
    {
        [Key]
        public int EscuelaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }


        public void Insert(AppDbContext dbContext)
        {
            dbContext.Escuelas.Add(this);
            dbContext.SaveChanges();
        }
    }
}
