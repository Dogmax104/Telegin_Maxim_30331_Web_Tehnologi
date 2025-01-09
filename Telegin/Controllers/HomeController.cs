using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Telegin.UI.Models;

namespace Telegin.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<ListDemo> _listData;
        public HomeController (ILogger<HomeController> logger)
        {
            _logger = logger;
            _listData = new List<ListDemo>
            {
            new ListDemo {Id=1, Name="Item 1"},
            new ListDemo {Id=2, Name="Item 2"},
            new ListDemo {Id=3, Name="Item 3"}
            };
        }
        public IActionResult Index()
        {
            ViewData["Lab2_Text"] = "Лабораторная работа №2";
            ViewBag.Item = new SelectList(_listData, "Id", "Name");

            // Передадим данные для определения пользователя:
            LocalUser localUser = new LocalUser();
            string? NameRegistrView = TempData["Usersin"]!=null ? TempData["Usersin"].ToString() : 
                "User@gmail.com";
            ViewBag.Usersin = NameRegistrView;
            return View();
        }
    }

    public class ListDemo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
