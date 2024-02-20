using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public class City: BaseEntity
    {
        public string Name { get; init; }
        public string State { get; init; }
        public string? Website { get; init; }

        public City()
        {}
        public City(Guid id, string name, string state, string? website)
        {
            Id = id;
            Name = name;
            State = state;
            Website = website;
        }

        public City(string name, string state, string? website)
        {
            Name = name;
            State = state;
            Website = website;
        }
    }
}
