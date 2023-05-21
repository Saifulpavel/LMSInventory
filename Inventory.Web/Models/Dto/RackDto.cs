using Inventory.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models.Dto
{
    public class RackDto
    {
        public int Id { get; set; }
        //[DisplayName("Rack Name")]
        public string Name { get; set; }
        public int QuantityOfRacks { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }
}
