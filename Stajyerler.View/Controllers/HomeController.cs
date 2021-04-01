using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stajyerler.MVC.Helper;
using Stajyerler.MVC.Models;
using Stajyerler.View.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stajyerler.View.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private RoleManager<AppRole> RoleMgr { get; }
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

        public HomeController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
            RoleMgr = roleManager;
        }

        public IActionResult RegisterIntern()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterIntern(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    University = model.University,
                    Major = model.Major,
                    Department = model.Department,
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await UserMgr.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    UserMgr.AddToRoleAsync(user, "Intern").Wait();
                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        StajyerAPI _api = new StajyerAPI();
        public async Task<IActionResult> Index()
        {
            List<StajyerData> stajyerlers = new List<StajyerData>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/stajyers");
            if (res.IsSuccessStatusCode) {
                var results = res.Content.ReadAsStringAsync().Result;
                stajyerlers = JsonConvert.DeserializeObject<List<StajyerData>>(results);
            }
            return View(stajyerlers);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var stajogr = new StajyerData();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"api/stajyers/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                stajogr = JsonConvert.DeserializeObject<StajyerData>(results);
            }
            return View(stajogr);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            StajyerData stajyer = new StajyerData();

            using (HttpClient httpClient = _api.initial())
            {
                using (var response = await httpClient.GetAsync("api/stajyers/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stajyer = JsonConvert.DeserializeObject<StajyerData>(apiResponse);
                }
            }
            return View(stajyer);
        }

        [HttpPost]
        public IActionResult Edit(StajyerData stajyer)
        {
            using (HttpClient httpClient = _api.initial())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44327/api/stajyers");

                //HTTP POST
                var putTask = httpClient.PutAsJsonAsync<StajyerData>("stajyers", stajyer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(stajyer);
        }

        [HttpPost]
        public IActionResult Create(StajyerData stajyer)
        {
            HttpClient client = _api.initial();

            //Http Post
            var postTask = client.PostAsJsonAsync<StajyerData>("api/stajyers", stajyer);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var stajyer = new StajyerData();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/stajyers/{Id}");
            return RedirectToAction("Index");
        }

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(ProjectRole role)
        {
            var roles = new AppRole
            {
                Name = role.RoleName,
            };

            var roleExist = await RoleMgr.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await RoleMgr.CreateAsync(roles);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }
            }
            return View(role);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
