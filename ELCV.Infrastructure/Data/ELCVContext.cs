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
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextSettings dbContextSettings = new DbContextSettings();
            IConfigurationRoot configuration = dbContextSettings.SetConfigurationSettings();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString((dbContextSettings.GetDataFileSettings()["DBConnectionStringName"])));
            base.OnConfiguring(optionsBuilder);
        }

        


    }
}   

    
         

       
 

