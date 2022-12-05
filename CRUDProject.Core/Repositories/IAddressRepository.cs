using CRUDProject.Core.Models;

namespace CRUDProject.Core.Repositories
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetAddressesWithCustomer();
    }
}
