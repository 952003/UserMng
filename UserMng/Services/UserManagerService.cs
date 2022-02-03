using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.Identity;
using UserMng.Interfaces;
using UserMng.ViewModels;

namespace UserMng.Services
{
    public class UserManagerService : IUserManagerServices
    {
        private readonly IdentityDBContext dbContext;
        private readonly IMapper mapper;

        public UserManagerService(IdentityDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<UserVM> GetAllUsers()
        {
            var users = dbContext.Users.AsNoTracking();
            var usersVM = mapper.Map<IEnumerable<UserVM>>(users);
            return usersVM;
        }

        public async Task<bool> BlockUsersAsync(IEnumerable<int> ids)
        {
            await dbContext.Users.Where(u => ids.Contains(u.Id)).ForEachAsync(u => u.IsBlocked = true);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnblockUsersAsync(IEnumerable<int> ids)
        {
            await dbContext.Users.Where(u => ids.Contains(u.Id)).ForEachAsync(u => u.IsBlocked = false);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsersAsync(IEnumerable<int> ids)
        {
            dbContext.RemoveRange(dbContext.Users.Where(u => ids.Contains(u.Id)));
            await dbContext.SaveChangesAsync();
            return true;
        } 
    }
}
