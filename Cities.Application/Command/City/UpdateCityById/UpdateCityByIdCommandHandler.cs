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

namespace Cities.Application.Command.City.UpdateCityById
{
    public class UpdateCityByIdCommandHandler(ICityRepository cityRepository, IMapper mapper) : IRequestHandler<UpdateCityByIdCommand, UpdateCityByIdResponse>
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<UpdateCityByIdResponse> Handle(UpdateCityByIdCommand request, CancellationToken cancellationToken)
        {
            ValidationException.When(request.Id.Equals(Guid.Empty), ErrorCodeEnum.InvalidCityId.ToString(), (int)ErrorCodeEnum.EmptyCityRequest);
            ValidationException.When(request.Body is null, ErrorCodeEnum.EmptyCityRequest.ToString(), (int)ErrorCodeEnum.EmptyCityRequest);

            Cities.Core.Entities.City cityResult = await _cityRepository.GetById(request.Id);
            ValidationException.When(cityResult is null, ErrorCodeEnum.CityDoesNotExist.ToString(), (int)ErrorCodeEnum.CityDoesNotExist);

            Cities.Core.Entities.City city = new(request.Id, request.Body.Name, request.Body.State, request.Body.Website);
            UpdateCityByIdResponse response = new();

            response = _mapper.Map<UpdateCityByIdResponse>(await _cityRepository.Update(city));
            response.Success = true;
            return response;
        }
    }
}
