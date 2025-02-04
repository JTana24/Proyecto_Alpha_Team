

using System.Data.Entity;

namespace Proyecto_Alpha_Team.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<TipoIdentificacion> TipoIdentificaciones { get; set; }
    }
}
