using CRUDProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDProject.Repository.Seeds
{
    internal class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer { Id = 1, Name = "Eyüp", Surname = "Birankar", CreatedDate = DateTime.Now },
                            new Customer { Id = 2, Name = "Çağlar", Surname = "Demir", CreatedDate = DateTime.Now }
            );
        }
    }
}
