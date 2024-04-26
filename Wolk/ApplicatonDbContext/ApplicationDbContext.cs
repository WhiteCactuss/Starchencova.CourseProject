using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolk.Entites;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wolk.ApplicatonDbContext
{
    public class ApplicationDbContext : DbContext
    {
        //public const string ConnectionString = @"Server=localhost\SQLExpress;Database=Schedule;Trusted_Connection=true;Encrypt=false"; //Home
        public const string ConnectionString = @"Server=PC-232-10;Database=Schedule;Trusted_Connection=true;Encrypt=false"; //RRV
        //public const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Schedule;Trusted_Connection=true;Encrypt=false"; //LHK

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasKey(x => x.Id);

            modelBuilder.Entity<Audience>().HasKey(x => x.Id);
            
            modelBuilder.Entity<Group>().HasKey(x => x.Id);

            modelBuilder.Entity<Schedule>().HasKey(x => x.Id);

            modelBuilder.Entity<Teacher>().HasKey(x => x.Id);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Schedules)
                .WithOne(x => x.Subject)
                .HasForeignKey(x => x.SubjectId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Schedules)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId)
                .IsRequired();


            modelBuilder.Entity<Audience>()
                .HasMany(s => s.Schedules)
                .WithOne(x => x.Audience)
                .HasForeignKey(x => x.AudienceId)
                .IsRequired();

        }
    }
}
