using AutoMapper;
using Inventory.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace Inventory.Web.Controllers
{
    public class RackController : Controller
    {
        readonly Uri baseAddress = new("https://localhost:44336/api");
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public RackController(IMapper mapper)
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RackIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllRacks()
        {
            try
            {
                List<RackDto> list = new();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Rack/Get").Result;
                if (response.IsSuccessStatusCode && response != null)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<RackDto>>(data);
                }
                return Json(list.ToArray());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateRack(RackDto obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Rack/Create", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Rack created successfully");
                }
                else
                {
                    return Json("Rack not created");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateRack(RackDto obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Rack/Update/" + obj.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Rack updated successfully");
                }
                else
                {
                    return Json("Rack not updated");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult DeleteRack(int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(id);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Rack/Delete/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Rack deleted successfully");
                }
                else
                {
                    return Json("Rack not deleted");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            
        }
    }
}
