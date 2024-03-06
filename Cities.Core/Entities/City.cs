using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public sealed class City(Guid id, string name, string state, string? website) : BaseEntity
    {
        public string Name { get; init; } = name;
        public string State { get; init; } = state;
        public string? Website { get; init; } = website;

        public City(string name, string state, string? website) : this(Guid.Empty, name, state, website) { }
    }
}
    