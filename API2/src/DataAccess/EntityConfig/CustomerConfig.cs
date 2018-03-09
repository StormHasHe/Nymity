using System.Data.Entity.ModelConfiguration;
using Contracts.Entities;

namespace DataAccess.EntityConfig
{
    public class CustomerConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerConfig()
        {
            HasKey(u => u.CustomerID);

            Property(u => u.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            Property(u => u.ContactName)
                .IsOptional()
                .HasMaxLength(30);

            Property(u => u.ContactTitle)
                .IsOptional()
                .HasMaxLength(30);

            Property(u => u.Address)
                .IsOptional()
                .HasMaxLength(60);

            Property(u => u.City)
                .IsOptional()
                .HasMaxLength(15);

            Property(u => u.Region)
                .IsOptional()
                .HasMaxLength(15);

            Property(u => u.PostalCode)
                .IsOptional()
                .HasMaxLength(10);

            Property(u => u.Country)
                .IsOptional()
                .HasMaxLength(15);

            Property(u => u.Phone)
                .IsOptional()
                .HasMaxLength(24);

            Property(u => u.Fax)
                .IsOptional()
                .HasMaxLength(24);

            ToTable("Customers");
        }
    }
}