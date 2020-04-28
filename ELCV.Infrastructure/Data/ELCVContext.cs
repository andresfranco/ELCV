using ELCV.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json.Linq;
using ELCV.Core.Handlers;

namespace ELCV.Infrastructure.Data
{
    public class ELCVContext : DbContext
    {
        public ELCVContext(DbContextOptions<ELCVContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<SystemParameter> SystemParameters { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ResumeSkill> ResumeSkills { get; set; }
        public DbSet<PersonSkill> PersonSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>()
                   .HasIndex(u => u.CountryCode)
                   .IsUnique();
            builder.Entity<Country>()
                    .HasMany(c => c.States)
                    .WithOne(s => s.Country);
            builder.Entity<Country>()
                   .HasMany(c => c.Cities)
                   .WithOne(ci => ci.Country);
            builder.Entity<State>()
                   .HasOne(s =>s.Country)
                   .WithMany(c =>c.States).Metadata.DeleteBehavior = DeleteBehavior.Restrict;      
            builder.Entity<State>()
                   .HasMany(ci => ci.Cities)
                   .WithOne(s => s.State);
            builder.Entity<City>()
                  .HasOne(ci => ci.Country)
                  .WithMany(c => c.Cities).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
                
            builder.Entity<City>()
                 .HasOne(ci => ci.State)
                 .WithMany(s => s.Cities)
                 .IsRequired();
            builder.Entity<City>()
                   .HasIndex(u => u.CityCode)
                   .IsUnique();
            builder.Entity<State>()
                   .HasIndex(u => u.StateCode)
                   .IsUnique();

            builder.Entity<SystemParameter>()
                   .HasIndex(u => u.ParameterCode)
                   .IsUnique();

            builder.Entity<WorkExperience>()
                   .HasOne(w => w.Resume)
                   .WithMany(r => r.WorkExperiences)
                   .HasForeignKey(w => w.ResumeForeignKey);

            builder.Entity<ResumeSkill>()
                   .HasOne(rs => rs.Resume)
                   .WithMany(r => r.ResumeSkills)
                   .HasForeignKey(rs => rs.ResumeId);

            builder.Entity<ResumeSkill>()
                   .HasOne(rs => rs.Skill)
                   .WithMany(s => s.ResumeSkills)
                   .HasForeignKey(rs => rs.SkillId);

            builder.Entity<PersonSkill>()
                   .HasOne(ps => ps.Person)
                   .WithMany(p => p.PersonSkills)
                   .HasForeignKey(ps => ps.PersonId);

            builder.Entity<PersonSkill>()
                   .HasOne(ps => ps.Skill)
                   .WithMany(s => s.PersonSkills)
                   .HasForeignKey(ps => ps.SkillId);
        }

    }


}







