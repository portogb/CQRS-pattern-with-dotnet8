using AutoMapper;
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

namespace Cities.Application.Command.City
{
    public class CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper) : IRequestHandler<CreateCityCommand, CreateCityResponse>
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {   
            ValidationException.When(request.Equals(null), ErrorCodeEnum.EmptyCityRequest.ToString(), (int)ErrorCodeEnum.EmptyCityRequest);

            Cities.Core.Entities.City cityResult = await _cityRepository.GetByName(request.Name);
            ValidationException.When(cityResult is not null, ErrorCodeEnum.CityAlreadyExist.ToString(), (int)ErrorCodeEnum.CityAlreadyExist);

            Cities.Core.Entities.City cityEntity = new(request.Name, request.State, request.Website);
            cityResult = await _cityRepository.Create(cityEntity);
            ValidationException.When(request.Equals(null), ErrorCodeEnum.ErrorCreatingCity.ToString(), (int)ErrorCodeEnum.ErrorCreatingCity);

            CreateCityResponse response = new()
            {
                Success = true,
            };

            response = _mapper.Map<CreateCityResponse>(cityEntity);

            return response;
        }
    }
}
