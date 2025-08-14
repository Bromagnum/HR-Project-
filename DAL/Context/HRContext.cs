using DAL.Configurations.Concretes;
using DAL.Entities.Concretes;
using DAL.Entities.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class HRContext : IdentityDbContext
    {
        public HRContext()
        {
        }   
        public HRContext(DbContextOptions<HRContext> options) : base(options)
        {
        }
        // DbSet

        public DbSet<Personel> Personels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=HRProject;User Id=Bromagnum\\GÖKTUĞ;TrustServerCertificate=True;Trusted_Connection=True;");
            }


            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignore ServiceResponse<Guid> for all entities
           

            //Personel Configuration

            modelBuilder.ApplyConfiguration(new PersonelConfiguration());

            base.OnModelCreating(modelBuilder);
            
        }

        
    }
}
