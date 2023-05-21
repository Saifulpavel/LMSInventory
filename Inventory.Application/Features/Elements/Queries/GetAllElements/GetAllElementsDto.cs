using Inventory.Application.Common.Mappings;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.Elements.Queries.GetAllElements
{
    public class GetAllElementsDto : IMapFrom<Element>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Width { get; init; }
        public string Height { get; init; }
        public int RackId { get; init; }      
        public string RackName { get; init; }
    }
}
