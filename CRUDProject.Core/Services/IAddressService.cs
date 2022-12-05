using CRUDProject.Core.DTOs;
using CRUDProject.Core.Models;

namespace CRUDProject.Core.Services
{
    public interface IAddressService : IService<Address>
    {
        Task<ResponseDataDto<List<Address>>> GetAddressesByIds(IEnumerable<int> ids);
        Task<ResponseDataDto<List<AddressWithCustomerDto>>> GetAddressesWithCustomer();
    }
}
