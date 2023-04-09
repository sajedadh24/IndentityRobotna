using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndentityRobotna.Models.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Option):base(Option)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Curse> Curses { get; set; }


    }
}
