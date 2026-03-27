using AutoMapper;
using CustomerOperatorDatabaseApi.Entities;
using CustomerOperatorDatabaseApi.Model;

namespace CustomerOperatorDatabaseApi.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.OperatorName,
                    opt => opt.MapFrom(src => src.Operator.Name));

            CreateMap<CustomerForCreationDto, Customer>()
                .ForMember(dest => dest.Operator, opt => opt.Ignore());
        }
    }
}