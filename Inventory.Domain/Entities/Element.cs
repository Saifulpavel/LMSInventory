using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Element : BaseAuditableEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Width { get; set; }
        [MaxLength(10)]
        public string Height { get; set; }
        public int? RackId { get; set; }
        public Rack Rack { get; set; }
    }
}
