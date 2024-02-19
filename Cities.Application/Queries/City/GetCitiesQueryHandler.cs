using Cities.Application.Enums;
using Cities.Application.Validation;
using Cities.Core.Entities;
using Cities.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Queries.City
{
    public class GetCitiesQueryHandler(ICityRepository cityRepositoy) : IRequestHandler<GetCitiesQuery, GetCitiesResponse>
    {
        private readonly ICityRepository _cityRepository = cityRepositoy;
        private readonly 

        public async Task<GetCitiesResponse> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Cities.Core.Entities.City> cities = await _cityRepository.GetCities();
            ValidationException.When(cities is null, ErrorCodeEnum.CityDoesNotExist.ToString(), (int)ErrorCodeEnum.CityDoesNotExist);

            GetCitiesResponse response = new();

            response.Success = true;

        }
    }
}
