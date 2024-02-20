using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Command.City.DeleteCityById
{
    public record DeleteCityByIdCommand :IRequest<DeleteCityByIdResponse>
    {
        [FromRoute]
        public Guid Id { get; init; }
    }
}
