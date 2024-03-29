﻿using Cities.Application.Command.City.CreateCity;
using Cities.Application.Command.City.DeleteCityById;
using Cities.Application.Command.City.UpdateCityById;
using Cities.Application.Queries.City.GetCities;
using Cities.Application.Queries.City.GetCityById;
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
            CreateMap<City, GetCitiesItemResponse>().ReverseMap();
            CreateMap<City, CreateCityResponse>().ReverseMap();
            CreateMap<City, GetCityByIdResponse>().ReverseMap();
            CreateMap<City, DeleteCityByIdResponse>().ReverseMap();
            CreateMap<City, UpdateCityByIdCommand>().ReverseMap();
            CreateMap<City, UpdateCityByIdResponse>().ReverseMap();
        }
    }
}
