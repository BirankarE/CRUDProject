using CRUDProject.Core.Models;
using CRUDProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetCustomerByIdWithAddressAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.Addresses).Where(x => x.Id == customerId).FirstOrDefaultAsync();
        }
    }
}
