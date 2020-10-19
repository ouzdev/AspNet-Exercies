using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net.Core.Identity.Context
{
    public class AspCoreIdentityContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-FG6OGDC\SQLEXPRESS; database=OG.AspNetCoreIdentityDB; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
