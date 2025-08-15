using DAL.Configurations.Concretes;
using DAL.Entities.Abstracts;
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
        //SaveChangesAsync override

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAudit();
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAudit();
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAudit();
                        break;

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
