using AutoMapper;
using UserMng.Identity.Entities;
using UserMng.ViewModels;

namespace UserMng.MappingProfiles
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<UserVM, User>().ReverseMap();
            CreateMap<UserSignUpVM, User>();
            CreateMap<UserSignUpVM, UserSignInVM>();
        }
    }
}
