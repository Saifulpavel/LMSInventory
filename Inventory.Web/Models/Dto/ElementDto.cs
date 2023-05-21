using Inventory.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models.Dto
{
    public class ElementDto
    {
        public int Id { get; set; }
        [DisplayName("Element Name")]
        public string Name { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public int RackId { get; set; }
        public string RackName { get; set; }
    }
}
