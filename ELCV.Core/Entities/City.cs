﻿using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELCV.Core.Entities
{
   public class City:Entity
    {
        public string CityCode { get; set; }
        public string Name { get; set; }
        public State State{ get; set; }
        public Country Country { get; set; }
    }
}
