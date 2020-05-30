using AutoMapper;

namespace BankIdService.Infrastructure.Profiles
{
    internal class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Entities.AuthModel, Application.Models.AuthModel>();
        }
    }
}
