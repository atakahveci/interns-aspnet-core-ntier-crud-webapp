using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Stajyerler.View.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Stajyerler.View.Controllers
{
    public class GeneralController : Controller
    {
        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

        public GeneralController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(/*[FromBody]*/ LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInMgr.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StajyerJwtTokens.Key));
                    var credentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.Email)
                    };
                    var token = new JwtSecurityToken(
                        StajyerJwtTokens.Issuer,
                        StajyerJwtTokens.Audience,
                        claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credentials
                    );

                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };
                   
                    if (user.Email=="admin@gmail.com" && user.Password=="Admin123!")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //return Created("", results);
                    return RedirectToAction("Profil", "Account");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View("../General/Login", user);
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();

            return RedirectToAction("Login", "General");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
