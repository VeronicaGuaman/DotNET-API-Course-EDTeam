using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newwebapi.Models;

namespace newwebapi.Context
{
    public class ApiAppContext : DbContext
    {
        public DbSet<User> Users {get; set;}
         
        public ApiAppContext(DbContextOptions<ApiAppContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<User> userInitData = new List<User>();

            userInitData.Add(new User{Name = "Vero", LastName="Guaman"});
            userInitData.Add(new User{Name = "User 1", LastName="LastName 1"});
            userInitData.Add(new User{Name = "User 2", LastName="LastName 2"});

            builder.Entity<User>().ToTable("User").HasData(userInitData);
            builder.Entity<User>().HasKey(p => p.UserId);
        }
    }
}