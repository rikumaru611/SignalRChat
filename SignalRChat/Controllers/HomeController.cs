using Microsoft.AspNetCore.Mvc;
using SignalRChat.Data;
using SignalRChat.Models;
using System.Diagnostics;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignalRChatContext _db;


        public HomeController(ILogger<HomeController> logger, SignalRChatContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var User = _db.Users.Where(u => u.UserName == "user2@user2.user2"); 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}