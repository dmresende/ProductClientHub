using ProductClientHub.API.Infrastrucure;
using ProductClientHub.API.UseCases.Product.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();

            Validate(dbContext, clientId, request);


            var entity = new Entities.Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId
            };

            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private void Validate(ProductClientHubDbContext dbContext, Guid clientId,RequestProductJson request)
        {
            var clientExist = dbContext.Clients.Any(client => client.Id == clientId);
            if (!clientExist)
                throw new NotFoundException("Client not found.");


            var validator = new RequestProductValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
