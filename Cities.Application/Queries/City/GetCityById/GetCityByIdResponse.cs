using Cities.Application.Common;

namespace Cities.Application.Queries.City.GetCityById
{
    public class GetCityByIdResponse : CommonResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string? Website { get; set; }
    }
}