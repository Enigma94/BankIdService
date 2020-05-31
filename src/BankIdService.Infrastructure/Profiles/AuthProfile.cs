using AutoMapper;

namespace BankIdService.Infrastructure.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Entities.AuthResponseModel, Application.Models.AuthResponseModel>().ReverseMap();
            CreateMap<Entities.AuthRequestModel, Application.Models.AuthRequestModel>().ReverseMap();
        }
    }
}
