using Microsoft.EntityFrameworkCore;
using WebApiTickets.Models;

namespace WebApiTickets.DataBase
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tiquetes> listaTiquetes { get; set; }
        public DbSet<Usuarios> listaUsuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasKey(x => x.ro_identificador);
            modelBuilder.Entity<Tiquetes>().HasKey(x => x.ti_identificador);
            modelBuilder.Entity<Usuarios>().HasKey(x => x.us_identificador);

            modelBuilder.Entity<Tiquetes>()
                .HasOne(t => t.Roles)
                .WithMany()
                .HasForeignKey(t => t.ti_us_id_asigna);

            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Roles)
                .WithMany()
                .HasForeignKey(u => u.us_ro_identificador);

        
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            modelBuilder.Entity<Tiquetes>().ToTable("Tiquetes");
        }


    }
}
