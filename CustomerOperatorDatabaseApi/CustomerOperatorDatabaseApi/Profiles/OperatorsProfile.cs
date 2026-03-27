using AutoMapper;
using CustomerOperatorDatabaseApi.Entities;
using CustomerOperatorDatabaseApi.Model;

namespace CustomerOperatorDatabaseApi.Profiles
{
    public class OperatorsProfile : Profile
    {
        public OperatorsProfile()
        {
            CreateMap<Operator, OperatorDto>()
                .ForMember(dest => dest.Emails,
                    opt => opt.MapFrom(src => src.Emails.Select(e => e.Address)));

            CreateMap<OperatorForCreationDto, Operator>()
                .ForMember(dest => dest.Emails,
                    opt => opt.MapFrom(
                        src => src.Emails.Select(e => 
                            new Email { Address = e }).ToList()
                    )
                );
        }
    }
}