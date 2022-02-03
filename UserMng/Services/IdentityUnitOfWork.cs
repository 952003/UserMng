using Microsoft.AspNetCore.Identity;
using System;
using UserMng.Identity.Entities;
using UserMng.Interfaces;

namespace UserMng.Services
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        public SignInManager<User> SignInManager { get; set; }

        public UserManager<User> UserManager { get; set; }

        public IdentityUnitOfWork(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        #region Disposable

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                }
                disposedValue = true;
            }
        }

        ~IdentityUnitOfWork()
         {
            Dispose(disposing: false);
         }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable
    }
}
