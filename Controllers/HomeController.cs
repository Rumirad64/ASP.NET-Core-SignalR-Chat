using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRApp.Hubs;
using SignalRApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHubContext<ChatHub> _hubContext;
        //Inject an instance of IHubContext in a controller
        //to emit msgs in controller

        public HomeController(ILogger<HomeController> logger , IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()

        {
            
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"You visited privacy() at: {DateTime.Now}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
