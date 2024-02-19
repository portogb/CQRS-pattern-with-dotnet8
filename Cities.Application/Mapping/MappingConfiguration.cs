using Cities.Application.Queries.City;
using Cities.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Mapping
{
    public class MappingConfiguration : AutoMapper.Profile
    {
        public MappingConfiguration()
        {
            CreateMap<City, GetCitiesResponse>().ReverseMap();
        }
    }
}
