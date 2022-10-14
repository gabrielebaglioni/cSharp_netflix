using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharp_netflix.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cSharp_netflix.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MediaController : Controller
    {
        // GET: /<controller>/
        
        ApplicationDbContext _ctx;
        public MediaController()
        {
            _ctx = new ApplicationDbContext();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Actor> actors = _ctx.Actors.ToList();
            return Ok(actors);
        }
    }
}

