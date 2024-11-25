using ABCMoneyTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ABCMoneyTransfer.Controllers
{
    public class CurrentExchange : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrentExchange(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentExchange()
        {
            string apiUrl = "https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from=2024-06-12&to=2024-06-12";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Unable to fetch exchange rates.";
                return View(new List<Rate>());
            }
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var payload = JsonConvert.DeserializeObject<PayloadWrapper>(jsonResponse)?.Data?.Payload;
            if (payload == null || payload.Count == 0)
            {
                ViewBag.Error = "No data available.";
                return View(new List<Rate>());
            }

            // Extract rates from the first payload (assuming single payload for the given date range)
            var rates = payload[0].Rates;

            return View(rates);
        }
    }

    public class PayloadWrapper
    {
        public PayloadData Data { get; set; }
    }

    public class PayloadData
    {
        public List<Payload> Payload { get; set; }
    }
}
