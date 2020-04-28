using ELCV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Infrastructure.Data.Repositories
{
    public class CityRepository:EfAsyncRepository<City>
    {
        public CityRepository(ELCVContext repositoryContext) :base(repositoryContext){}
    }
}
