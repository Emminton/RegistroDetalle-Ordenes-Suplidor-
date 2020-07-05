using Microsoft.EntityFrameworkCore;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.DaLL
{
    public class Contexto : DbContext
    {
        
        public DbSet<Ordene> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }    
        public DbSet<Suplidore> Suplidores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\OrdenDetalleDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                ProductoId = 1,
                Descripcion = "Salsa",
                Costo = 250,
                Inventario = 0
            });

            modelBuilder.Entity<Suplidore>().HasData(new Suplidore
            {
                SuplidorId = 1,
                Nombre = "Grupo Ramos"
            });

            modelBuilder.Entity<Producto>().HasData(new Producto
            {
                ProductoId = 2,
                Descripcion = "Arroz",
                Costo = 25,
                Inventario = 0
            });

            modelBuilder.Entity<Suplidore>().HasData(new Suplidore
            {
                SuplidorId = 2,
                Nombre = "El Yoma"
            });

        }
    }
}
