using AutoMapper;
using CRUDProject.Core.DTOs;
using CRUDProject.Core.Models;
using CRUDProject.Core.Repositories;
using CRUDProject.Core.Services;
using CRUDProject.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CRUDProject.Service.Services
{
    public class AddressService : Service<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IUnitOfWork unitOfWork, IGenericRepository<Address> repository, IAddressRepository addressRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDataDto<List<AddressWithCustomerDto>>> GetAddressesWithCustomer()
        {
            var address = await _addressRepository.GetAddressesWithCustomer();
            var addressDto = _mapper.Map<List<AddressWithCustomerDto>>(address);
            return ResponseDataDto<List<AddressWithCustomerDto>>.Success(200, addressDto);
        }

        public async Task<ResponseDataDto<List<Address>>> GetAddressesByIds(IEnumerable<int> ids)
        {
            var adresses = await _addressRepository.Where(x => ids.Contains(x.Id)).ToListAsync();
            var adressesDto = _mapper.Map<List<Address>>(adresses);
            return ResponseDataDto<List<Address>>.Success(200, adressesDto);
        }
    }
}
