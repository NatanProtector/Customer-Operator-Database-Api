using AutoMapper;
using CustomerOperatorDatabaseApi.Entities;
using CustomerOperatorDatabaseApi.Model;

namespace CustomerOperatorDatabaseApi.Profiles
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<Email, EmailDto>();

            CreateMap<EmailForCreationDto, Email>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<EmailForUpdatingDto, Email>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Operators, opt => opt.Ignore());
        }
    }
}