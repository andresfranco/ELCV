using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class SystemParameter : Entity
    {
        public string ParameterCode { get; set; }
        public string ParameterValue { get; set; }
    }
}
