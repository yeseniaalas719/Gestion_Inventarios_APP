using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Gestion_Inventarios_APP.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }

    public class DbContexto : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
    }
}