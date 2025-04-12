using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public class NotFoundException : ProductsClientHubException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }

        public override List<string> GetErros() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
