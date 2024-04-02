using Microsoft.EntityFrameworkCore;
namespace ESTUDIANTES_BE.Models
{
    //DbContext da acceso a la base de datos
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options):base(options) { }
        //Realizamos un dbSet por cada tabla que deseemos agregar a la base de datos
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
    }
}
