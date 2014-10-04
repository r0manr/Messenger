using AutoMapper;
using MessangerFirst.Core.Model;
using MessangerFirst.WebUI.ViewModels;

namespace MessangerFirst.WebUI.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }


        protected override void Configure()
        {
            Mapper.CreateMap<User, RegisterViewModel>();
            Mapper.CreateMap<Message, MessageViewModel>()
                      .ForMember(r => r.Reciever,
                       m => m.MapFrom(a => a.Reciever.Email)
                      )
                      .ForMember(s => s.Sender,
                       m => m.MapFrom(a => a.Sender.Email)
                      );
            Mapper.CreateMap<User, EditAccountViewModel>();
            Mapper.CreateMap<User, UserViewModel>();
        }
    }
}