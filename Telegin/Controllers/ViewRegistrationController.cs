using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Telegin.Data;
using Telegin.UI.Models;

namespace Telegin.UI.Controllers
{
    public class ViewRegistrationController : Controller
    {
        public readonly ApplicationDbContext _context;  // свойство контекста;
        // GET: ViewRegistration
        public ActionResult RegistrationUser()
        {
            return View("_RegistrationUser");
        }

        // Метод для добовления пользователя:
        // Конструктор для передачи контекста:
        public ViewRegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Метод для проверки в базе данных значения:
        public  bool ValidNamePassword(LocalUser Users)
        {
            var _username = Users.Name;
            var _password = Users.Password;
            bool namecot = _context.LocalUser.Any(u => u.Name == _username && u.Password == _password);
            return namecot;
        }
        
        // Метод регистрации пользователя в базе данных;
        public ActionResult AddUser([FromForm] LocalUser localUser)
        {
            if (!ValidNamePassword(localUser))
            {
                _context.LocalUser.Add(localUser);
                _context.SaveChanges();
                TempData["Usersin"] = localUser.Name;
                return RedirectToAction("Index","Home");
            }
            TempData["Usersin"] = localUser.Name;
            return RedirectToAction("Index","Home");
        }
    }
}
