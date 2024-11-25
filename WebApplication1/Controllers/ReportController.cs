using ABCMoneyTransfer.Models;
using ABCMoneyTransfer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ABCMoneyTransfer.Controllers
{
    public class ReportController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;

        public ReportController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            List<Payment> payments;

            if (startDate.HasValue && endDate.HasValue)
            {
                // Fetch filtered payments
                payments = _paymentRepository.GetPaymentsByDateRange(startDate.Value, endDate.Value);
            }
            else
            {
                payments = new List<Payment>(); // Empty list if no filters are applied
            }

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View(payments);
        }
    }
}
