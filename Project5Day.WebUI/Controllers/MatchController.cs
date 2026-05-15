using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project5Day.WebUI.Dtos.MatchDtos;
using System.Text;


namespace Project5Day.WebUI.Controllers
{
    public class MatchController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CreateMatch()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7194/api/Team");
            var json = await response.Content.ReadAsStringAsync();
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(json);

            ViewBag.Teams = teams;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7194/api/Match", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CreateMatch");
            }

            return View();
        }
        public async Task<IActionResult> MatchList()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7194/api/Match");

            var jsonData = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultMatchDto>>(jsonData);

            return View(values);
        }
        public async Task<IActionResult> MatchDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // MATCH
            var response = await client.GetAsync($"https://localhost:7194/api/Match/{id}");

            var jsonData = await response.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<ResultMatchDetailDto>(jsonData);

            // MATCH EVENTS
            var eventResponse = await client.GetAsync($"https://localhost:7194/api/MatchEvent/{id}");

            var eventJson = await eventResponse.Content.ReadAsStringAsync();

            var events = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(eventJson);

            ViewBag.Events = events;

            return View(value);
        }

    }
}