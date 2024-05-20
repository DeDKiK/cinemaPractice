using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Users> User { get; set;}
        public DbSet<Films> Films { get; set;}  
        public DbSet<Hall> Hall { get; set;}
        public DbSet<Session> Session { get; set;}

    }
}