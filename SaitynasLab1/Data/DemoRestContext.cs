using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaitynasLab1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace SaitynasLab1.Data
{
    public class DemoRestContext : DbContext
    {
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=RestDemo");
        }
    }
}
