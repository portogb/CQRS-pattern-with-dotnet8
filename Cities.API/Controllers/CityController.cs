using Cities.Application.DTO;
using Cities.Application.Enums;
using Cities.Application.Queries.City;
using Cities.Core.Entities;
using Cities.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Cities.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/cities")]
    public class CityController(IMediator mediator, ILogger logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger _logger = logger;

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                GetCitiesResponse response = await _mediator.Send(new GetCitiesQuery());
                return Ok(new MessageResponse(true, 0, null, response));
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new MessageResponse
                    (false, 
                    404, 
                    "Error getting cities",
                    new Error 
                    { 
                        Code = 404, 
                        Description = ex.Message
                    }));
            }
        }

        //[HttpPost()]
        //public async Task<IActionResult> Post([FromBody] City city)
        //{
        //    try
        //    {
        //        City response = await _cityRepository.Create(city);
        //        return Ok(response);
        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //        return BadRequest(ex);
        //    }
        //}
    }
}
