using Demo.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
    public class MVCDbContext : IdentityDbContext<Applicationuser>
    {
        public MVCDbContext(DbContextOptions<MVCDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        // optionsBuilder.UseSqlServer("server=.; Database =MVC ;Trusted_Connectio =true;");
        //}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}

