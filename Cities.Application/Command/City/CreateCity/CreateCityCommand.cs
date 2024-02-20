using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cities.Application.Command.City.CreateCity
{
    public record CreateCityCommand : IRequest<CreateCityResponse>
    {
        [JsonPropertyName("name")]
        public string? Name { get; init; }
        [JsonPropertyName("state")]
        public string? State { get; init; }
        [JsonPropertyName("website")]
        public string? Website { get; init; }
    }
}
