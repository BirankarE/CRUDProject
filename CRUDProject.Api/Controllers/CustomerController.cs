using AutoMapper;
using CRUDProject.Core.DTOs;
using CRUDProject.Core.Models;
using CRUDProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.Api.Controllers
{
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetSingleCustomerByIdWithAddressAsync(int customerId)
        {
            return CreateActionResult(await _customerService.GetCustomerByIdWithAddressAsync(customerId));
        }

        ///GET api/address
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _customerService.GetAllAsync();
            var CustomersDto = _mapper.Map<List<CustomerDto>>(customers.ToList());

            return CreateActionResult(ResponseDataDto<List<CustomerDto>>.Success(200, CustomersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _customerService.GetByIdAsync(id);
            var CustomersDto = _mapper.Map<CustomerDto>(customers);

            return CreateActionResult(ResponseDataDto<CustomerDto>.Success(200, CustomersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto CustomerDto)
        {
            var customer = await _customerService.AddAsync(_mapper.Map<Customer>(CustomerDto));
            var CustomersDto = _mapper.Map<CustomerDto>(customer);

            return CreateActionResult(ResponseDataDto<CustomerDto>.Success(201, CustomersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerDto)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return CreateActionResult(ResponseDataDto<CustomerUpdateDto>.Success(204));
        }

        ///DELETE api/address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            await _customerService.RemoveAsync(customer);

            return CreateActionResult(ResponseDataDto<CustomerDto>.Success(204));
        }
    }
}
