using Microsoft.AspNetCore.Mvc;

namespace ms2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientTestController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ClientTestController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7056/"); // Base URL of the first microservice
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsFromMicroservice1()
        {
            var response = await _httpClient.GetAsync("Test");
            if (response.IsSuccessStatusCode)
            {
                var items = await response.Content.ReadFromJsonAsync<List<string>>();
                return Ok(items);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Failed to retrieve items from Microservice1");
            }
        }
    }
}