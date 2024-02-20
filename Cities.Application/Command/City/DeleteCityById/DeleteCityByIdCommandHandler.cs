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
            Cities.Core.Entities.City city = await _cityRepository.GetById(request.Id);
            ValidationException.When(city is null, ErrorCodeEnum.CityDoesNotExist.ToString(), (int)ErrorCodeEnum.CityDoesNotExist);

            _ = _cityRepository.Remove(city);
            DeleteCityByIdResponse response = new()
            {
                Success = true
            };

            return response;
        }
    }
}
