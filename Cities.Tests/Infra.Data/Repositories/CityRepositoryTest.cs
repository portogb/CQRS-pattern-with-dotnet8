using Cities.Core.Entities;
using Cities.Core.Interfaces;
using Cities.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Tests.Infra.Data.Repositories
{
    public class CityRepositoryTest : AppTestContext
    {
        private readonly ICityRepository _cityRepository;

        public CityRepositoryTest()
        {
            _cityRepository = new CityRepository(_context);
            Setup();
        }

        [Fact]
        public async Task GivenRequestAllCities_WhenCompleted_ThenReturnSuccess()
        {
            IEnumerable<Core.Entities.City> cities = await _cityRepository.GetCities();
            Assert.NotNull(cities);
        }

        [Fact]
        public async Task GivenRequestCityById_WhenCompleted_ThenReturnSuccess()
        {
            var city = await _cityRepository.GetById(Guid.Parse("057a43dc-a09c-47c4-a1df-caa9b2095281"));
            Assert.NotNull(city);
        }

        [Fact]
        public async Task GivenRequestCityByName_WhenCompleted_ThenReturnSuccess()
        {
            var city = await _cityRepository.GetByName("Test Name");
            Assert.NotNull(city);
        }

        [Fact]
        public async Task GivenCreateCityRequest_WhenCompleted_ThenReturnSuccess()
        {
            var city = new Core.Entities.City(new Guid(), "any city name", "any state name", string.Empty);
            city = await _cityRepository.Create(city);
            Assert.NotNull(city);
        }

        [Fact]
        public async Task GivenDeleteCityRequest_WhenCompleted_ThenReturnSuccess()
        {
            var city = new Core.Entities.City(Guid.Parse("b2258eef-16a5-4f92-955f-3080ad7ea8d7"), "city name", "state name", string.Empty);
            city = await _cityRepository.Create(city);
            await _cityRepository.Remove(city);

            var cityExists = await _cityRepository.GetByName("city name");
            Assert.Null(cityExists);
        }

        private void Setup()
        {
            _context.Cities.Add(new Core.Entities.City(Guid.Parse("057a43dc-a09c-47c4-a1df-caa9b2095281"), "Test Name", "Test State", string.Empty));
            _context.Cities.Add(new Core.Entities.City(Guid.Parse("1eabd270-1ea8-40d6-87e9-634add932890"), "Test Name 2", "Test State 2", "Test Url 2"));

            _context.SaveChangesAsync(true, default).GetAwaiter().GetResult();
        }
    }
}
