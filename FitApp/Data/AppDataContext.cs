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
        public DbSet<UsuarioModel>? Usuarios { get; set; }
        public DbSet<RegistrarModel>? Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.Registros)
            .WithOne()
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade); //adicionar essa linha para poder excluir em cascata
            

            base.OnModelCreating(modelBuilder);
        }

    }
    
}