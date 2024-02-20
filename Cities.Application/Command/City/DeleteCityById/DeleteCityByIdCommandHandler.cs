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

namespace Cities.Application.Command.City.DeleteCityById
{
    public class DeleteCityByIdCommandHandler(ICityRepository cityRepository, IMapper mapper) : IRequestHandler<DeleteCityByIdCommand, DeleteCityByIdResponse>
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<DeleteCityByIdResponse> Handle(DeleteCityByIdCommand request, CancellationToken cancellationToken)
        {
            ValidationException.When(request.Id.Equals(Guid.Empty), ErrorCodeEnum.InvalidCityId.ToString(), (int)ErrorCodeEnum.InvalidCityId);

            Cities.Core.Entities.City city = await _cityRepository.GetById(request.Id);
            ValidationException.When(city is null, ErrorCodeEnum.CityDoesNotExist.ToString(), (int)ErrorCodeEnum.CityDoesNotExist);

            await _cityRepository.Remove(city);

            Cities.Core.Entities.City existCity = await _cityRepository.GetById(request.Id);
            ValidationException.When(existCity is not null, ErrorCodeEnum.CityNotDeleted.ToString(), (int)ErrorCodeEnum.CityNotDeleted);

            DeleteCityByIdResponse response = new()
            {
                Success = true
            };

            return response;
        }
    }
}
