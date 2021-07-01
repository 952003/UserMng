using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.Identity.Entities;

namespace UserMng.Interfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        SignInManager<User> SignInManager { get; }
        UserManager<User> UserManager { get; }
    }
}
