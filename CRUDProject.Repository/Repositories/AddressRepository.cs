using CRUDProject.Core.Models;
using CRUDProject.Core.Repositories;
using CRUDProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Repository.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Address>> GetAddressesWithCustomer()
        {
            //Eager Loading Addressler ekilirken Customerda çekiliyor
            return await _context.Addresses.Include(x => x.Customer).ToListAsync();
        }
    }
}
