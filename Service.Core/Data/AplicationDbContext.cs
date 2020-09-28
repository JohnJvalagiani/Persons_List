using IG.Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IG.Core.Data
{
   public class AplicationDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }


        public AplicationDbContext(DbContextOptions<AplicationDbContext> context):base(context)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ConnectedPerson>()
            .HasOne(c => c.Person)
            .WithMany(p => p.ConectedPerson)
            .HasForeignKey(c=>c.ForeignKey)
            .OnDelete(DeleteBehavior.Cascade); 


            modelBuilder.Entity<Person>()
                .Property(p => p.FirstNameGEO)
                .IsRequired();

            modelBuilder.Entity<Person>()
              .Property(p => p.LastNameGEO)
              .IsRequired();

            modelBuilder.Entity<Person>()
               .Property(p => p.FirstNameENG)
               .IsRequired();

            modelBuilder.Entity<Person>()
              .Property(p => p.LastNameENG)
              .IsRequired();


            modelBuilder.Entity<Person>()
                .Property(p => p.PhoneNumber)
                .IsRequired();

           

            modelBuilder.Entity<Person>()
               .Property(p => p.PersonalNumber)
               .IsRequired()
               .HasMaxLength(11);
               

            modelBuilder.Entity<Person>()
               .Property(p => p.BirthDate)
               .IsRequired();

            modelBuilder.Entity<Person>()
               .Property(p => p.Adress)
               .IsRequired();

        }

    }
}
