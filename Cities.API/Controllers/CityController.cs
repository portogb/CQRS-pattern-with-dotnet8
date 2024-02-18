using Cities.Core.Entities;
using Cities.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Cities.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/cities")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository) => _cityRepository = cityRepository;

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                IEnumerable<City> cities = await _cityRepository.GetCities();
                return Ok(cities);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            try
            {
                City response = await _cityRepository.Create(city);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
