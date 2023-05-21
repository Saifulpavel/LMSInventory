using Inventory.Application.Common.Mappings;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Racks.Queries.GetRackById
{
    public class GetRackByIdDto : IMapFrom<Rack>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int QuantityOfRacks { get; init; }
        public int StoreId { get; init; }
        public string StoreName { get; init; }
    }
}
