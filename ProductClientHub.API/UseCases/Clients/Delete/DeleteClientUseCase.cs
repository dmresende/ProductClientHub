﻿using ProductClientHub.API.Infrastrucure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid id) 
        {
            var dbContext = new ProductClientHubDbContext();
            var entity = dbContext.Clients.FirstOrDefault(client => client.Id == id);

            if (entity is null)
                throw new NotFoundException("Client not found.");

            dbContext.Clients.Remove(entity);
            dbContext.SaveChanges();

        }
    }
}
