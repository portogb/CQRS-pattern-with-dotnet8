using Cities.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCities();
        Task<City> GetById(Guid id);
        Task<City> Create(City city);
        Task<City> Update(City city);
        Task Remove(City city);
    }
}
