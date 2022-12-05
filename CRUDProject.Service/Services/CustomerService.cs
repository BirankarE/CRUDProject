using AutoMapper;
using CRUDProject.Core.DTOs;
using CRUDProject.Core.Models;
using CRUDProject.Core.Repositories;
using CRUDProject.Core.Services;
using CRUDProject.Core.UnitOfWork;

namespace CRUDProject.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IGenericRepository<Customer> repository, ICustomerRepository customerRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDataDto<CustomerWithAddressDto>> GetCustomerByIdWithAddressAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdWithAddressAsync(customerId);
            var customerDto = _mapper.Map<CustomerWithAddressDto>(customer);

            return ResponseDataDto<CustomerWithAddressDto>.Success(200, customerDto);
        }
    }
}
