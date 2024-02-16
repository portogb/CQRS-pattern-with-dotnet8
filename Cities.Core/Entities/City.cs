using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public class City(string name, string state, string? website) : BaseEntity
    {
        public string Name { get; private set; } = name;
        public string State { get; private set; } = state;
        public string? Website { get; private set; } = website;
        public List<Restaurant> Restaurants { get; private set; } = [];
        public List<Hotel> Hotels { get; private set; } = [];
        public List<TouristPackage> TouristPackages { get; set; } = [];
    }
}
