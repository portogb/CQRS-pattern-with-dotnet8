using Cities.Application.Command.City.CreateCity;
using Cities.Application.Command.City.DeleteCityById;
using Cities.Application.Command.City.UpdateCityById;
using Cities.Application.DTO;
using Cities.Application.Enums;
using Cities.Application.Queries.City.GetCities;
using Cities.Application.Queries.City.GetCityById;
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
        public async Task<IActionResult> Get()
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
                    ex.Message,
                    new Error
                    {
                        Code = 404,
                        Description = ex.Message
                    }));
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] CreateCityCommand command)
        {
            try
            {
                CreateCityResponse response = await _mediator.Send(command);
                return Ok(new MessageResponse(true, 0, "City created", response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new MessageResponse
                    (false,
                    404,
                    ex.Message,
                    new Error
                    {
                        Code = 404,
                        Description = ex.Message
                    }));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(GetCityByIdQuery query)
        {
            try
            {
                GetCityByIdResponse response = await _mediator.Send(query);
                return Ok(new MessageResponse(true, (int)StatusCodeEnum.Success, null, response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new MessageResponse
                    (false,
                     (int)StatusCodeEnum.BadRequest,
                     ex.Message,
                     new Error
                     {
                         Code = (int)StatusCodeEnum.BadRequest,
                         Description = ex.Message
                     }));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteCityByIdCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(new MessageResponse(true, 0, null, (int)StatusCodeEnum.Success));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new MessageResponse
                    (false,
                    (int)StatusCodeEnum.BadRequest,
                    ex.Message,
                    new Error
                    {
                        Code = (int)StatusCodeEnum.BadRequest,
                        Description = ex.Message
                    }));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(UpdateCityByIdCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(new MessageResponse(true, (int)StatusCodeEnum.Success, null, response));
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new MessageResponse
                    (false,
                    (int)StatusCodeEnum.BadRequest,
                    ex.Message,
                    new Error
                    {
                        Code = (int)StatusCodeEnum.BadRequest,
                        Description = ex.Message,
                        Name = ex.Message
                    }));
            }
        }
    }
}
