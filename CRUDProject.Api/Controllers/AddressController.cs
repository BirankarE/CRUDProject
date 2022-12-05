using AutoMapper;
using CRUDProject.Core.DTOs;
using CRUDProject.Core.Models;
using CRUDProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.Api.Controllers
{
    public class AddressController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAddressService _service;
        public AddressController(IService<Address> service, IMapper mapper, IAddressService addressService)
        {
            _mapper = mapper;
            _service = addressService;
        }

        ///GET api/address/GetAddressesWithCustomer
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAddressesWithCustomer()
        {
            return CreateActionResult(await _service.GetAddressesWithCustomer());
        }

        ///GET api/address
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var addresses = await _service.GetAllAsync();
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses.ToList());

            return CreateActionResult(ResponseDataDto<List<AddressDto>>.Success(200, addressDtos));
        }

        ///GET api/address/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _service.GetByIdAsync(id);
            var addressDto = _mapper.Map<AddressDto>(address);

            return CreateActionResult(ResponseDataDto<AddressDto>.Success(200, addressDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(AddressDto addressDto)
        {
            var address = await _service.AddAsync(_mapper.Map<Address>(addressDto));
            var addressesDto = _mapper.Map<AddressDto>(address);

            return CreateActionResult(ResponseDataDto<AddressDto>.Success(201, addressesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddressUpdateDto addressDto)
        {
            if (addressDto.Id == 0)
            {
                var address = await _service.AddAsync(_mapper.Map<Address>(addressDto));
                var addressesDto = _mapper.Map<AddressDto>(address);
                return CreateActionResult(ResponseDataDto<AddressDto>.Success(201, addressesDto));
            }
            else
            {
                await _service.UpdateAsync(_mapper.Map<Address>(addressDto));

                return CreateActionResult(ResponseDataDto<AddressUpdateDto>.Success(204));
            }

        }

        ///DELETE api/address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var address = await _service.GetByIdAsync(id);
            if (address == null)
                return CreateActionResult(ResponseDataDto<AddressDto>.Fail(404, "Adres Bulunamadi"));
            await _service.RemoveAsync(address);

            return CreateActionResult(ResponseDataDto<AddressDto>.Success(204));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRange(IEnumerable<int> ids)
        {
            var addresses = await _service.GetAddressesByIds(ids);
            if (addresses?.Data == null || !addresses.Data.Any())
                return CreateActionResult(ResponseDataDto<AddressDto>.Fail(404, "Adres listesi boş"));

            await _service.RemoveRangeAsync(addresses.Data);
            return CreateActionResult(ResponseDataDto<List<AddressDto>>.Success(204));
        }
    }
}
