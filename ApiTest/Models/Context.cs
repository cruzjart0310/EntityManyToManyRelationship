using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Assigment> Assigment { get; set; }

        public DbSet<AssigmentStudent> AssigmentStudent { get; set; }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Survey> Survey { get; set; }
        public DbSet<Question> Question { get; set; }

        public DbSet<Answer> Answer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            var options = optionsBuilder.UseSqlServer("Server=DESKTOP-K7S3PRT;Database=EntityTest;Integrated Security=True")
                .EnableSensitiveDataLogging()
              .Options;
            //}

            //optionsBuilder.UseSqlServer("Server=DESKTOP-K7S3PRT;Database=backend;Integrated Security=True");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssigmentStudent>()
           .HasKey(ec => new { ec.AssigmentId, ec.StudentId });

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Assigments)
                .WithMany(y => y.Students)
                .UsingEntity<AssigmentStudent>(
                    x => x.HasOne(x => x.Assigment)
                    .WithMany().HasForeignKey(x => x.AssigmentId),
                    x => x.HasOne(x => x.Student)
                    .WithMany().HasForeignKey(x => x.StudentId)
                );

            modelBuilder.Entity<Profile>();
            modelBuilder.Entity<Country>();
            modelBuilder.Entity<State>();
            modelBuilder.Entity<City>();


            

            modelBuilder.Entity<Profile>().HasData(
                new Profile { Id = 1, Nickname="nickname", Avatar="avatar.jpg"}
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Mexico" }
            );

            modelBuilder.Entity<State>().HasData(
               new Country { Id = 1, Name = "Aguascaliente" }
               
            );

            modelBuilder.Entity<City>().HasData(
               new Country { Id = 1, Name = "Valle verde", }
           );

            //modelBuilder.Entity<Student>().HasData(
            //    new Profile { Id = 1, Nickname = "nickname", Avatar = "avatar.jpg" },
            //    new Address
            //    {
            //        Id = 1,
            //        Title = "My address",
            //        StrretAdrress = "1St Aven 145",
            //        Country = new Country { Id = 1, Name = "Mexico" },
            //        State = new State { Id = 1, Name = "Aguascalientes" },
            //        City = new City { Id = 1, Name = "Valle verde", }
            //    }
            //);

            base.OnModelCreating(modelBuilder);

        }
    }
}
