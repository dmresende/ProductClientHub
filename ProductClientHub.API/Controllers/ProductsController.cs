using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Products.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId}")]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Register([FromRoute] Guid clientId, RequestProductJson request)
        {
            var response = new RegisterProductUseCase();
            response.Execute(clientId, request);

            return Created(string.Empty, response);
        }
    }
}
