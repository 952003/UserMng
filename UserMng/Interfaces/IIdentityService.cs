using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.ViewModels;

namespace UserMng.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignUp(UserSignUpVM userVM);

        Task<bool> SignIn(UserSignInVM userVM);

        Task SignOut();
    }
}
