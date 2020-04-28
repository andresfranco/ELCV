using ELCV.Core.Entities;
using ELCV.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELCV.Infrastructure.Data
{
   public class CountryRepository:EfAsyncRepository<Country>
    {
        public CountryRepository(ELCVContext repositoryContext):base(repositoryContext){}
       

    }
}
