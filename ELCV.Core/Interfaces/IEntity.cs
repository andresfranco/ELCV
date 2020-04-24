using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get;set; }
    }
}
