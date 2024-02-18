using Cities.Core.Entities;
using Cities.Core.Interfaces;
using Cities.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Infra.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dbContext;

        public CityRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task<City> Create(City city)
        {
            await _dbContext.AddAsync(city);
            await _dbContext.SaveChangesAsync();
            return city;
        }

        public async Task<City> GetById(Guid id)
        {
            return await _dbContext
                .Cities
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _dbContext
                .Cities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Remove(City city)
        {
            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<City> Update(City city)
        {
            _dbContext.Update(city);
            await _dbContext.SaveChangesAsync();
            return city;
        }
    }
}
