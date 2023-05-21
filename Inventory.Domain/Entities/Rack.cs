using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Rack : BaseAuditableEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int QuantityOfRacks { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
    }
}
