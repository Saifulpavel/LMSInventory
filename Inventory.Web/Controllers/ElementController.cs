using Inventory.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.Web.Controllers
{
    public class ElementController : Controller
    {
        readonly Uri baseAddress = new("https://localhost:44336/api");
        private readonly HttpClient _client;
        public ElementController()
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }
        
        public IActionResult ElementIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllElements()
        {
            try
            {
                List<ElementDto> list = new();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Element/Get").Result;
                if (response.IsSuccessStatusCode && response != null)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<ElementDto>>(data);
                }
                return Json(list.ToArray());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateElement(ElementDto obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Element/Create", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Element created successfully");
                }
                else
                {
                    return Json("Element not created");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }       
        }

        [HttpPost]
        public IActionResult UpdateElement(ElementDto obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Element/Update/" + obj.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Element updated successfully");
                }
                else
                {
                    return Json("Element not updated");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult DeleteElement(int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(id);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Element/Delete/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Element deleted successfully");
                }
                else
                {
                    return Json("Element not deleted");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
