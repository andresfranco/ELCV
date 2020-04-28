using ELCV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Infrastructure.Data.Repositories
{
    public class StateRepository:EfAsyncRepository<State>
    {
        public StateRepository(ELCVContext repositoryContext) :base(repositoryContext){}
    }
}
