using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.Identity;
using UserMng.Identity.Entities;
using UserMng.Interfaces;
using UserMng.ViewModels;

namespace UserMng.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityUnitOfWork identityUnitOfWork;
        private readonly IdentityDBContext identityContext;

        public IdentityService(IIdentityUnitOfWork identityUnitOfWork, IdentityDBContext identityContext)
        {
            this.identityUnitOfWork = identityUnitOfWork;
            this.identityContext = identityContext;
        }

        public async Task<bool> SignIn(UserSignInVM userVm)
        {
            var res = await identityUnitOfWork.SignInManager.PasswordSignInAsync(userVm.Login, userVm.Password, false, false);
            if (res.Succeeded)
            {
                var user = identityContext.Users.FirstOrDefault(u => u.UserName == userVm.Login);
                if(user != null)
                {
                    user.LastOnlineDate = DateTime.Now;
                    await identityContext.SaveChangesAsync();
                }
            }
            return res.Succeeded;
        }

        public async Task SignOut()
        {
            await identityUnitOfWork.SignInManager.SignOutAsync();
        }

        public async Task<bool> SignUp(UserSignUpVM userVm)
        {
            var user = new User
            {
                Email = userVm.Email,
                UserName = userVm.Login,
                RegisterDate = DateTime.Now
            };
            var res = await identityUnitOfWork.UserManager.CreateAsync(user, userVm.Password);
            return res.Succeeded;
        }
    }
}
