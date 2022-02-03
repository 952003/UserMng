using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserMng.Identity.Entities;

namespace UserMng.Identity
{
    public class IdentityDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public IdentityDBContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
