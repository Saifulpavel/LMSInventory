using Inventory.Application.Common.Mappings;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Stores.Queries.GetStoreById
{
    public class GetStoreByIdDto : IMapFrom<Store>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Country { get; init; }
    }
}
