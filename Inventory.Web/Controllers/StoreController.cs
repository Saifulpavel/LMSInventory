using Inventory.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.Web.Controllers
{
    public class StoreController : Controller
    {
        readonly Uri baseAddress = new("https://localhost:44336/api");
        private readonly HttpClient _client;
        public StoreController()
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }
        public IActionResult StoreIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllStores()
        {
            try
            {
                List<StoreDto> list = new();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Store/Get").Result;
                if (response.IsSuccessStatusCode && response != null)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<StoreDto>>(data);                    
                }
                return Json(list.ToArray());
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateStore(StoreDto obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Store/Create", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Store created successfully");
                }
                else
                {
                    return Json("Store not created");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateStore(StoreDto obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Store/Update/" + obj.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Store updated successfully");
                }
                else
                {
                    return Json("Store not updated");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult DeleteStore(int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(id);
                StringContent content = new(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Store/Delete/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Store deleted successfully");
                }
                else
                {
                    return Json("Store not deleted");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
