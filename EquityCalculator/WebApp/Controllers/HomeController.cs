using ApplicationCore.LoanModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoanViewModel loanViewModel)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var httpMessage = await client.GetAsync("https://localhost:7207/api/loan/addloan?sellingPrice=" + loanViewModel.sellingPrice +
                                                        "&reserveDate=" + loanViewModel.reserveDate +
                                                        "&equityTerm=" + loanViewModel.equityTerm);
                var jsonResponse = await httpMessage.Content.ReadAsStringAsync();
                LoanModel loanModel = JsonSerializer.Deserialize<LoanModel>(jsonResponse);
                ViewData["loanModel"] = loanModel;
            }
            
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