using AutoMapper;
using Cities.Application.Enums;
using Cities.Application.Validation;
using Cities.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Queries.City.GetCityById
{
    public class GetCityByIdQueryHandler(ICityRepository cityRepository, IMapper mapper) : IRequestHandler<GetCityByIdQuery, GetCityByIdResponse>
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<GetCityByIdResponse> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            ValidationException.When(request is null, ErrorCodeEnum.CityDoesNotExist.ToString(), (int)ErrorCodeEnum.CityDoesNotExist);

            Cities.Core.Entities.City city = await _cityRepository.GetById(request.Id);

            GetCityByIdResponse response = new()
            {
                Success = true
            };

            response = _mapper.Map<GetCityByIdResponse>(city);
            return response;
        }
    }
}
