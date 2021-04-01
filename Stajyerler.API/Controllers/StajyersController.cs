using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stajyerler.Business.Abstract;
using Stajyerler.Business.Concrete;
using Stajyerler.Entities;
using Stajyerler.View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stajyerler.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class StajyersController : ControllerBase
    {
        private IStajyerService _StajyerService;
        public StajyersController()
        {
            _StajyerService = new StajyerManager();
        }

        [HttpGet]
        public List<Stajyer> Get()
        {
            return _StajyerService.GetAllStajyers();

        }

        [HttpGet("{Id}")]
        public Stajyer Get(int Id) 
        {
            return _StajyerService.GetStajyerId(Id);
        
        }

        [HttpPost]
        public Stajyer Post([FromBody] Stajyer stajyer) 
        {
            return _StajyerService.CreateStajyer(stajyer);
        
        }

        [HttpPut]
        public Stajyer Put([FromBody] Stajyer stajyer)
        {
            return _StajyerService.UpdateStajyer(stajyer);

        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _StajyerService.DeleteStajyer(Id);

        }



    }
}
