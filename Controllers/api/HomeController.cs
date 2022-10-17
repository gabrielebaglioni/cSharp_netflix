using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cSharp_netflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cSharp_netflix.Controllers.api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        // GET: /<controller>/

        ApplicationDbContext _ctx;
        public HomeController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpGet]
        public IActionResult Get(string? name)
        {
            IQueryable<Actor> actors;

            if (name != null)
            {
                actors = _ctx.Actors.Where(actor => actor.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                actors = _ctx.Actors;
            }

            return Ok(actors.ToList<Actor>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Actor actor = _ctx.Actors.Where(e => e.Id == id).FirstOrDefault();
            //List<Actor> actors = _ctx.Actors.ToList();
            return Ok(actor);
        }
    }
}

