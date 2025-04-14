using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.GetId;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Register([FromBody]RequestClientJson request)
        {
                var response = new RegisterClientUseCase();
                response.Execute(request);

                return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] Guid id ,[FromBody] RequestClientJson request)
        {
            var usecase =  new UpdateClientUseCase();

            usecase.Execute(id,request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var usecase = new GetAllClientsUseCase();

            var response = usecase.Execute();

            if (response.Clients.Count == 0 )
                return NoContent();

            return Ok(response);

        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var useCase = new GetClientByIdUseCase();

            var reponse = useCase.Execute(id);

            return Ok(reponse);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var useCase = new DeleteClientUseCase();
            
            useCase.Execute(id);

            return NoContent();
        }
    }
}
