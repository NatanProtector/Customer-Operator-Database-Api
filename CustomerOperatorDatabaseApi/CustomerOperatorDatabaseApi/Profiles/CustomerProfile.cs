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

            CreateMap<Email, EmailDto>();

            CreateMap<Operator, OperatorDto>()
                .ForMember(dest => dest.Emails,
                    opt => opt.MapFrom(src => src.Emails.Select(e => e.Address)));
        }
    }
}