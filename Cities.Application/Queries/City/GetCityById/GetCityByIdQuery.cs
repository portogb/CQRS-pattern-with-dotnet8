using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Queries.City.GetCityById
{
    public record GetCityByIdQuery : IRequest<GetCityByIdResponse>
    {
        [FromRoute]
        public Guid Id { get; init; }
    }
}
