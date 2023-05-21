using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models.Dto
{
    public class StoreDto
    {
        public int Id { get; set; }
        [DisplayName("Store Name")]
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
