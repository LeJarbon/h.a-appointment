
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ha.appointment.Models.Model.Context
{
    public class HADbContext : DbContext
    {
        public HADbContext(DbContextOptions<HADbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryMapping());
            //modelBuilder.ApplyConfiguration(new LocationMapping());
            //modelBuilder.ApplyConfiguration(new ServicesMapping());
            //modelBuilder.ApplyConfiguration(new ContactMapping());
        }
    }
}
