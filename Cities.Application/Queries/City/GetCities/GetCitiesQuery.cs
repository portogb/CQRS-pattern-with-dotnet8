using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Queries.City.GetCities
{
    public record GetCitiesQuery : IRequest<GetCitiesResponse>
    {

    }
}
