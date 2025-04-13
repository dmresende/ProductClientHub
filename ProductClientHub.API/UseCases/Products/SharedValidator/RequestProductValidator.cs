using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Product.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Brand cannot be empty");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price value is invalid");
        }
    }
}
