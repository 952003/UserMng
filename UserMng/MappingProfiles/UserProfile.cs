using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.Identity.Entities;
using UserMng.ViewModels;

namespace UserMng.MappingProfiles
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<UserVM, User>(); //.ReversMap()
            CreateMap<UserSignUpVM, User>();
            CreateMap<UserSignUpVM, UserSignInVM>();
        }
    }
}
