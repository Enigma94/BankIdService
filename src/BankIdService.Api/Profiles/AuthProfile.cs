using AutoMapper;
using BankIdService.Api.ApiModels;

namespace BankIdService.Api.Profiles
{
    internal class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Application.Models.AuthModel, AuthModelDto>();
        }
    }
}
