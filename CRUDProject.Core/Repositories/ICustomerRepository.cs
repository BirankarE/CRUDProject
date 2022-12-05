using CRUDProject.Core.Models;

namespace CRUDProject.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByIdWithAddressAsync(int customerId);
    }
}
