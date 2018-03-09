using System.Data.Entity;
using Contracts.Entities;
using DataAccess.EntityConfig;

namespace DataAccess.Context
{
    public class IdentityIsolationContext : DbContext
    {
        public IdentityIsolationContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}