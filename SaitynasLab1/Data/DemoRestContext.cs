using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SaitynasLab1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SaitynasLab1.Data.Dtos.Auth;

namespace SaitynasLab1.Data
{
    public class DemoRestContext : IdentityDbContext<SaitynasUser>
    {
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=RestDemo");
            //optionsBuilder.UseSqlServer("Server=tcp:saitynaslab1dbserver.database.windows.net,1433;Initial Catalog=SaitynasLab1_db2;Persist Security Info=False;User ID=juslaz2;Password=Petras123%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseSqlServer(
                "Data Source=tcp:saitynaslab1dbserver.database.windows.net,1433;Initial Catalog=SaitynasLab1_db2;User Id=juslaz2@saitynaslab1dbserver;Password=Petras123%");
        }
    }
}
