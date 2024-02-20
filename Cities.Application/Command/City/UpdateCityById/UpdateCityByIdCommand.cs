using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Command.City.UpdateCityById
{
    public record UpdateCityByIdCommand : IRequest<UpdateCityByIdResponse>
    {
        [FromRoute]
        public Guid Id { get; init; }
        [FromBody]
        public CityBody Body { get; set; }
    }

    public record CityBody
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string? Website { get; set; }
    }
}
