using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public class City(string name, string state, string? website) : BaseEntity
    {
        public string Name { get; init; } = name;
        public string State { get; init; } = state;
        public string? Website { get; init; } = website;
    }
}
