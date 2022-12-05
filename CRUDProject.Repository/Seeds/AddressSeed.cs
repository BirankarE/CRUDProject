using CRUDProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDProject.Repository.Seeds
{
    internal class AddressSeed : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(new Address { Id = 1, Name = "Manavlar,5, 78702, Yenice/ Karabük, Turkey", City = "Karabük", CustomerId = 1, CreatedDate = DateTime.Now },
                            new Address { Id = 2, Name = "Alincik Köyü,19, 23902, Sivrice/Bingol, Turkey", City = "Bingol", CustomerId = 1, CreatedDate = DateTime.Now },
                            new Address { Id = 3, Name = "Bali,27, 52800, Kumru/Alanya, Turkey", City = "Alanya", CustomerId = 2, CreatedDate = DateTime.Now }
           );
        }
    }
}
