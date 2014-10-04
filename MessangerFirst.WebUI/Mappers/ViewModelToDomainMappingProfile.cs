using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MessangerFirst.Core.Model;
using MessangerFirst.WebUI.ViewModels;

namespace MessangerFirst.WebUI.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RegisterViewModel, User>();
            Mapper.CreateMap<MessageViewModel, Message>()
                    .ForMember(r => r.Reciever, m => m = null)
                    .ForMember(s => s.Sender, m => m = null);
            Mapper.CreateMap<EditAccountViewModel, User>();
            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}