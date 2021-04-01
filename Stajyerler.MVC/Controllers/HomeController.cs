using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stajyerler.MVC.Helper;
using Stajyerler.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stajyerler.MVC.Controllers
{
    public class HomeController : Controller
    {
        StajyerAPI _api = new StajyerAPI();

        public async Task<IActionResult> Index() 
        {
            List<StajyerData> stajyerlers = new List<StajyerData>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/stajyers");
            if (res.IsSuccessStatusCode) 
            {
                var results = res.Content.ReadAsStringAsync().Result;
                stajyerlers = JsonConvert.DeserializeObject<List<StajyerData>>(results);
            }
            return View(stajyerlers);
        }





        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
