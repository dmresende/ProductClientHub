﻿namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public abstract class ProductsClientHubException : SystemException
    {
        public ProductsClientHubException(string errorMessage) : base(errorMessage)
        {
        }

        public abstract List<string> GetErros();

    }
}
