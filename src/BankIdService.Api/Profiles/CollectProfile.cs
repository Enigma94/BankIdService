using AutoMapper;
using BankIdService.Api.ApiModels;

namespace BankIdService.Api.Profiles
{
    public class CollectProfile : Profile
    {
        public CollectProfile()
        {
            CreateMap<Application.Models.CollectResponseModel, CollectResponseDto>();
        }
    }
}
