using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistence.Implementation
{
    public class RackRepository : IRackRepository
    {
        private readonly IGenericRepository<Rack> _repository;
        public RackRepository(IGenericRepository<Rack> repository)
        {
            _repository = repository;
        }
    }
}
