﻿using ProductClientHub.API.Infrastrucure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
           var dbContext = new ProductClientHubDbContext();
           var entity = dbContext.Products.FirstOrDefault(product => product.Id == id);
           
            if (entity is null)
                throw new NotFoundException("Product not found.");

            dbContext.Products.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
