using Cities.Application.Common;

namespace Cities.Application.Command.City.UpdateCityById
{
    public class UpdateCityByIdResponse : CommonResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string? Website { get; set; }
    }
}