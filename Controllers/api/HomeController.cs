
using cSharp_netflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


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

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _ctx.Actors == null)
            {
                return NotFound();
            }

            var actor = await _ctx.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            
            return Ok(actor);
        }
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            //if (!_ctx.Actors.Exists(x => x.Id == id))
            if(actor.Id != actor.Id)
            {

                return NotFound();
                
            }
            _ctx.Update(actor);
            _ctx.SaveChanges();

            
            return Ok(actor);
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Actor actor = _ctx.Actors.Where(p => p.Id == id).FirstOrDefault();

            if (actor == null)
            {
                return NotFound(new { Message = "Pizza non trovata" });
            }
            try
            {
                _ctx.Actors.Remove(actor);
                _ctx.SaveChanges();
            }
            catch (SqlException)
            {
                return NotFound();
            }

           
            return RedirectToPage("Index");
        }
    }
}

