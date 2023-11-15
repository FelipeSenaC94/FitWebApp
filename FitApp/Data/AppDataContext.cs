using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitApp.Models;
using Microsoft.EntityFrameworkCore;


namespace FitApp.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Registrar>? Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasKey(x => x.UserId);

            modelBuilder.Entity<Registrar>()
            .HasKey(x => x.RegistrarId);

            modelBuilder.Entity<Registrar>()
            .HasOne(x => x.Usuario)
            .WithMany(u => u.Registros)  // Aqui, indicamos que Usuario tem muitos Registros
            .HasForeignKey(e => e.UsuarioId);
        }

    }
    
}