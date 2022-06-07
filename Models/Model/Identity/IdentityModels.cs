using Ha.appointment.Models.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ha.appointment.Model.Identity
{

    public class MyUser : IdentityUser<int>
    {
       

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        //public virtual ICollection<Appointment> Appointment { get; set; }

    }
    public class MyUserRole : IdentityUserRole<int> {  }
    public class MyRole : IdentityRole<int> { }
    public class MyClaim : IdentityUserClaim<int> {
     
    }
    public class MyLogin : IdentityUserLogin<int> {


    }

    public class MyRoleClaim : IdentityRoleClaim<int> {  }
    public class MyUserToken : IdentityUserToken<int> {  }
    public class ApplicationDbContext : IdentityDbContext<MyUser, MyRole, int, MyClaim, MyUserRole, MyLogin, MyRoleClaim, MyUserToken>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            //modelBuilder.Entity<MyUser>()
            //.ToTable("Users");

            modelBuilder.Entity<MyUser>(b =>
            {
                b.ToTable("MyUser");

            });

            //modelBuilder.Entity<MyRole>()
            //    .ToTable("Roles");

            modelBuilder.Entity<MyRole>(role =>
            {
                role.ToTable("Roles");

            });

            //modelBuilder.Entity<MyUserRole>()
            //    .ToTable("UserRoles");
            modelBuilder.Entity<MyUserRole>(userRole =>
            {

                userRole.ToTable("UserRoles");

            });
            modelBuilder.Entity<MyClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<MyLogin>()
                .ToTable("UserLogins");

            modelBuilder.Entity<MyLogin>().HasNoKey();

            modelBuilder.Entity<MyUserToken>().HasNoKey();

            modelBuilder.Entity<MyClaim>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MyUser>().Property(r => r.Id).ValueGeneratedOnAdd();
         
            modelBuilder.Entity<MyRole>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MyClaim>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MyUserRole>().HasNoKey();


        }
    }

}
