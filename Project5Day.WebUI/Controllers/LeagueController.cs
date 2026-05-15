using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project5Day.WebUI.Dtos.LeagueDtos;

namespace Project5Day.WebUI.Controllers
{
    public class LeagueController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LeagueController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7194/api/League");

            var jsonData = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultLeagueDto>>(jsonData);

            return View(values);
        }
    }
}