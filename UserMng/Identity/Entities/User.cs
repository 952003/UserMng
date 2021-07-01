using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMng.Identity.Entities
{
    public class User : IdentityUser<int>
    {
        public bool IsBlocked { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastOnlineDate { get; set; }
    }
}
