using Microsoft.EntityFrameworkCore;
using UPCService.Models;

namespace UPCService {
    public class ProyectoDBContext : DbContext {
        public ProyectoDBContext(DbContextOptions<ProyectoDBContext> options) : base(options) {

        }
        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Distrito> Distritos {get; set;}
    }
}