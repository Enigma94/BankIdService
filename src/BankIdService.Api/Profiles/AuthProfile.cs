using AutoMapper;
using BankIdService.Api.ApiModels;

namespace BankIdService.Api.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Application.Models.AuthResponseModel, AuthResponseDto>();
            CreateMap<Application.Models.AuthRequestModel, AuthRequestDto>().ReverseMap();
        }
    }
}
