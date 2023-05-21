using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistence.Implementation
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IGenericRepository<Store> _repository;
        public StoreRepository(IGenericRepository<Store> repository)
        {
            _repository = repository;
        }
    }
}
