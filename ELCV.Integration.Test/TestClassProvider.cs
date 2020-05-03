using ELCV.Infrastructure.Data;
using ELCV.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ELCV.Integration.Test
{
    public class TestClassProvider
    {
        public HttpClient Client { get; private set; }

      
        public TestClassProvider()
        {
            string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/../../ELCV.UI/appsettings.json";
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                         .AddJsonFile(directoryPath)
                                                                         .Build();

            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                   {
                       builder.ConfigureServices(services => 
                       {
                           services.RemoveAll(typeof(ELCVContext));
                           services.AddDbContext<ELCVContext>(options =>
                           {
                               options.UseSqlServer(configuration.GetConnectionString("ELCVConnectionString"));
                           });

                       });

                   });

            Client = appFactory.CreateClient();
       
        }
    }
}
