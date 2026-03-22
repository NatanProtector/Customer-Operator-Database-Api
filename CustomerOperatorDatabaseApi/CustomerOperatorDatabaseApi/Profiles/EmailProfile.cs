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
        }
    }
}