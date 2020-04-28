using AutoMapper;
using ELCV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models.Profiles
{
    public class CityMappingProfile:Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
