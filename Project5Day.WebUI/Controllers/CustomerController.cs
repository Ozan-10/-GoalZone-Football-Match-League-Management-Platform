using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project5Day.WebUI.Dtos.CustomerDtos;

namespace Project5Day.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CustomerList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7194/api/Customer");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createCustomerDto);
            StringContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7194/api/Customer", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }
            return View(createCustomerDto);
        }
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7194/api/Customer/?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7194/api/GetCustomer/?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdCustomerDto>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7194/api/Customer", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }
            return View();
        }
    }
}
