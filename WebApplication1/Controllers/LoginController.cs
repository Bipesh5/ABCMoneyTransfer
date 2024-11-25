using ABCMoneyTransfer.Models;
using ABCMoneyTransfer.Models.ViewModel;
using ABCMoneyTransfer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace ABCMoneyTransfer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = _userRepository.GetUserByEmail(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Email is already registered.");
                return View(model);
            }

            // Use PasswordHasher to hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, model.Password);

            // Create the user object
            var user = new User
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                Password = hashedPassword,  // Store the hashed password
                EnteredDate = DateTime.Now
            };

            // Save user to the database
            _userRepository.AddUser(user);

            TempData["SuccessMessage"] = "Signup successful. Please log in.";
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // Use PasswordHasher to verify the password
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(null, user.Password, model.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            HttpContext.Session.SetString("FullName", $"{user.FirstName} {user.LastName}");
            HttpContext.Session.SetInt32("UserId", user.UserId);
            TempData["SuccessMessage"] = "Login successful.";
            return RedirectToAction("Index", "Dashboard");
        }




        private byte[] HashPasswordWithPBKDF2(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000)) 
            {
                return pbkdf2.GetBytes(32); 
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "Logout successful.";
            return RedirectToAction("Login");
        }


    }
}
