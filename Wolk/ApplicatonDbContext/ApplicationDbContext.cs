using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            modelBuilder.Entity<Subject>().HasKey(x => x.SubjectId);

            modelBuilder.Entity<Audience>().HasKey(x => x.AudienceId);
            
            modelBuilder.Entity<Group>().HasKey(x => x.GroupId);

            modelBuilder.Entity<Schedule>().HasKey(x => x.ScheduleId);

            modelBuilder.Entity<Teacher>().HasKey(x => x.TeacherId);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Schedule)
                .WithOne(o => o.Subject)
                .HasForeignKey<Schedule>(x => x.SubjectId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.Schedule)
                .WithOne(t => t.Teacher)
                .HasForeignKey<Schedule>(x => x.TeacherId)
                .IsRequired();

            modelBuilder.Entity<Audience>()
                .HasOne(s => s.Schedule)
                .WithOne(a => a.Audience)
                .HasForeignKey<Schedule>(x => x.AudienceId)
                .IsRequired();

        }
    }
}
