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
        public ELCVContext(DbContextOptions<ELCVContext> options):base(options){}
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

    }

   
}   

    
         

       
 

