using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastrucure;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {
            Validade(request);

            //Open conect database in ProductClientHubDbContext 
            var dbContext = new ProductClientHubDbContext();

            //Create new Client
            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email,
            };

            //Used orm for add client
            dbContext.Clients.Add(entity);

            dbContext.SaveChanges();

            return new ResponseShortClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validade(RequestClientJson request)
        {
            var validator = new RequestClientValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }

    }
}
