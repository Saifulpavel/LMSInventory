using Inventory.Domain.Entities;
using Inventory.Persistence.DbContexts;
using Inventory.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;

namespace Inventory.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReportController(ApplicationDbContext db)
        {
            _db= db;
        }
        public string GetReport()
        {
            StringBuilder sb = new StringBuilder();
            var elementList = _db.Elements
                .Select(s => new
                {
                    StoreName = s.Rack.Store.Name,
                    Country = s.Rack.Store.Country,
                    RackName = s.Rack.Name,
                    QuantityOfRacks = s.Rack.QuantityOfRacks,
                    ElementName = s.Name,
                    Width = s.Width,
                    Height = s.Height
                }).ToList();
            List<StoreDto> storeList = new();
            List<RackDto> rackList = new();
            storeList = _db.Stores
                .Select(s => new StoreDto
                {
                    Name = s.Name,
                    Country = s.Country
                })
                .Distinct()
                .ToList();
            rackList = _db.Racks
                   .Select(s => new RackDto
                   {
                       Name = s.Name,
                       QuantityOfRacks = s.QuantityOfRacks,
                       StoreName = s.Store.Name
                   })
                   .Distinct()
                   .ToList();
            sb.Append("<Stores>");
            foreach (var store in storeList)
            {
                // Store opening tag
                sb.Append("\r\n\t<Store Name=\""+ store.Name+ "\" Country=\""+store.Country+"\">");
                // Racks opening tag
                sb.Append("\r\n\t\t<Racks>");
                var filteredrackList = rackList.Where(w => w.StoreName == store.Name);
                foreach (var rack in filteredrackList)
                {
                    var totalElement = elementList.Where(w => w.RackName == rack.Name).Count();
                    //Rack opening tag
                    sb.Append("\r\n\t\t\t<Rack Name=\""+ rack.Name+ "\" QuantityOfRacks=\""+rack.QuantityOfRacks+"\" TotalElements=\""+ totalElement + "\">");
                    //Elements opening tag
                    sb.Append("\r\n\t\t\t\t<Elements>");
                    var filteredElementList = elementList.Where(w => w.RackName == rack.Name);
                    foreach (var element in filteredElementList)
                    {
                        // Element opening tag and closing tag
                        sb.Append("\r\n\t\t\t\t\t<Element Element=\""+ element.ElementName+ "\" Width=\""+element.Width+"\" Height=\""+element.Height+ "\" />");
                    }
                    //Elements closing tag
                    sb.Append("\r\n\t\t\t\t</Elements>");
                    //Rack (not plural) closing tag
                    sb.Append("\r\n\t\t\t</Rack>");
                }
                // Racks closing tag
                sb.Append("\r\n\t\t</Racks>");
                // Store closing tag
                sb.Append("\r\n\t</Store>");
            }
            sb.Append("\r\n</Stores>");
            return sb.ToString();

        }
    }
}
