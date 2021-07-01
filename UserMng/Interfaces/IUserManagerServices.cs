using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.ViewModels;

namespace UserMng.Interfaces
{
    public interface IUserManagerServices
    {
        IEnumerable<UserVM> GetAllUsers();

        Task<bool> BlockUsersAsync(IEnumerable<int> ids);

        Task<bool> UnblockUsersAsync(IEnumerable<int> ids);

        Task<bool> DeleteUsersAsync(IEnumerable<int> ids);
    }
}
