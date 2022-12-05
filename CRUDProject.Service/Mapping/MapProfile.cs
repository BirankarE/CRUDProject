using AutoMapper;
using CRUDProject.Core.DTOs;
using CRUDProject.Core.Models;

namespace CRUDProject.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Address, AddressWithCustomerDto>();
            CreateMap<Customer, CustomerWithAddressDto>();
        }
    }
}
