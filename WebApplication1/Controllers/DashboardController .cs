using Microsoft.AspNetCore.Mvc;

namespace ABCMoneyTransfer.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Ensure the user is logged in
            var fullName = HttpContext.Session.GetString("FullName");
            if (string.IsNullOrEmpty(fullName))
            {
                return RedirectToAction("Login", "Account");
            }

            // Pass the full name to the view
            ViewBag.FullName = fullName;
            return View();
        }
    }
}
