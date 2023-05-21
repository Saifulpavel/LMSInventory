using Inventory.Application.Interfaces.Repositories;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistence.Implementation
{
    public class ElementRepository : IElementRepository
    {
        private readonly IGenericRepository<Element> _repository;
        public ElementRepository(IGenericRepository<Element> repository)
        {
            _repository = repository;
        }
    }
}
