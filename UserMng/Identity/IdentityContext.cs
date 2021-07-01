using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMng.Identity.Entities;

namespace UserMng.Identity
{
    public class IdentityContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public IdentityContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
