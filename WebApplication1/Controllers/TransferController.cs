using ABCMoneyTransfer.Models;
using ABCMoneyTransfer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ABCMoneyTransfer.Controllers
{
    public class TransferController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IHttpClientFactory _httpClientFactory;


        public TransferController(IPaymentRepository paymentRepository, IHttpClientFactory httpClientFactory)
        {
            _paymentRepository = paymentRepository;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var payments = _paymentRepository.GetAllPayments();
            return View(payments);
        }

        public IActionResult Details(int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            if (payment == null)
                return NotFound();

            return View(payment);
        }

        public IActionResult Create()
        {
            var rate = GetMalaysiaRate().Result;

            if (rate is Rate myrRate)
            {
                ViewBag.ExchangeRate = myrRate.Sell;
            }
            else
            {
                ViewBag.ExchangeRate = 0;
                ViewBag.Error = "Unable to fetch the MYR exchange rate.";
            }

            return View(new Payment());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }

            payment.PaymentDate = DateTime.Now;

            // Retrieve the current exchange rate for MYR
            var malaysiaRate = await GetMalaysiaRate();

            if (malaysiaRate != null)
            {
                var currentExchangeRate = malaysiaRate.Sell; // Assuming Sell is a decimal value
                if (payment.ExchangeRate == Convert.ToDecimal(currentExchangeRate) && ( (payment.TransferAmount * Convert.ToDecimal(currentExchangeRate) - payment.PayoutAmount == 0))) 
                {
                    _paymentRepository.AddPayment(payment);
                    return RedirectToAction(nameof(Index));
                }
            }

            // If validation fails, add an error message and return to the view
            ModelState.AddModelError(string.Empty, "Invalid exchange rate or payout amount.");
            return View(payment);
        }

        private async Task<Rate> GetMalaysiaRate()
        {
            string apiUrl = "https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from=2024-06-12&to=2024-06-12";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var payload = JsonConvert.DeserializeObject<PayloadWrapper>(jsonResponse)?.Data?.Payload;

            return payload?.FirstOrDefault()?.Rates?.FirstOrDefault(r => r.Currency.Iso3 == "MYR");
        }
    }

}
