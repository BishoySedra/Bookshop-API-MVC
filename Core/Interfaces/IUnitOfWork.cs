﻿namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }

        IProductRepository Products { get; }

        Task<int> SaveAsync();
    }

}
