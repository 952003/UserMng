using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.Interfaces;
using UserMng.ViewModels;

namespace UserMng.Controllers
{
    [Authorize]
    public class UserManagerController : Controller
    {
        private readonly IUserManagerServices userManagerServices;

        public UserManagerController(IUserManagerServices userManagerServices)
        {
            this.userManagerServices = userManagerServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = (List<UserVM>)userManagerServices.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Block(IEnumerable<UserVM> usersVM)
        {
            var ids = GetUsersId(usersVM);
            var res = await userManagerServices.BlockUsersAsync(ids);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Unblock(IEnumerable<UserVM> usersVM)
        {
            var ids = GetUsersId(usersVM);
            var res = await userManagerServices.UnblockUsersAsync(ids);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<UserVM> usersVM)
        {
            var ids = GetUsersId(usersVM);
            var res = await userManagerServices.DeleteUsersAsync(ids);
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private IEnumerable<int> GetUsersId(IEnumerable<UserVM> usersVM)
        {
            var ids = usersVM.Where(u => u.Selected).Select(u => u.Id);
            return ids;
        }
    }
}
