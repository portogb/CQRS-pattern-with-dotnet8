using Cities.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Queries.City
{
    public class GetCitiesResponse : CommonResponse
    {
        public IEnumerable<GetCitiesItemResponse> Cities { get; set; }
    }

    public class GetCitiesItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string? Website { get; set; }
    }
}
