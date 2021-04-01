using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stajyerler.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stajyerler.View.Controllers
{
    [Route("apii/[controller]")]
    [Authorize(AuthenticationSchemes = StajyerJwtTokens.AuthSchemes)]
    public class hahacs : ControllerBase
    {
        [HttpGet]
        public List<string> GetCustomer() 
        {
            return new List<string>() { "customer1", "customer22" };
        }
        
    }
}
