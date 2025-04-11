using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]RequestClientJson request)
        {
            try
            {
                var response = new RegisterClientUseCase();
                response.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ProductsClientHubException ex)
            {
                var erros = ex.GetErros();
                return BadRequest(new ResponseErrorMessagesJson(erros));
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("Unknown error."));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Deçete()
        {
            return Ok();
        }
    }
}
