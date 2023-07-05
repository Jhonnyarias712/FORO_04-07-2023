using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{

    public class SchoolContext : DbContext
    {
        public DbSet<Auto> autos { get; set; }
        public DbSet<Color> colores { get; set; }
        public DbSet<Propietario> propietarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DB_Auto_transaccion;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Auto>().HasKey(v => v.Autoid);
            
        }

    }

}
