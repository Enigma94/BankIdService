using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace BankIdService.Infrastructure.Profiles
{
    public class CollectProfile : Profile
    {
        public CollectProfile()
        {
            CreateMap<Entities.CollectResponseModel, Application.Models.CollectResponseModel>()
                .ForMember(s => s.OrderRef, f => f.MapFrom(c => c.OrderRef))
                .ForMember(s => s.Status, f => f.MapFrom(c => c.Status))
                .ForMember(s => s.Name, f => f.MapFrom(c => c.CompletionData.User.Name))
                .ForMember(s => s.Surname, f => f.MapFrom(c => c.CompletionData.User.Surname))
                .ForMember(s => s.PersonalNumber, f => f.MapFrom(c => c.CompletionData.User.PersonalNumber))
                .ForMember(s => s.IpAddress, f => f.MapFrom(c => c.CompletionData.Device.IpAddress));
        }
    }
}
