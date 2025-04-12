using ProductClientHub.API.Infrastrucure;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetAll
{
    public class GetAllClientsUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            //type clients is List<EntitiesClient>
            var clients = dbContext.Clients.ToList();

            //link for selected client to list
            //if to try pass client of type List<EntitesClient> will return ERROR
            //necessary link for list of client have type correct
            var listClients = clients.Select(client => new ResponseShortClientJson
            {
                Id = client.Id,
                Name = client.Name,
            }).ToList();

            //for end, return list clients
            return new ResponseAllClientsJson
            {
                Clients = listClients
            };
            


        }
    }
}
