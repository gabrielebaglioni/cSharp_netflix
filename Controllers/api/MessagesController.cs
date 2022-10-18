using Microsoft.AspNetCore.Mvc;
using cSharp_netflix.Models;
namespace cSharp_netflix.Controllers.api
{
   
    namespace cSharp_netflix.Controllers.api
    {
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class MessagesController : ControllerBase
        {
          

            [HttpPost]
            public IActionResult Send([FromBody] Message message)
            {
                ApplicationDbContext _ctx = new ApplicationDbContext();
                _ctx.Messages.Add(message);
                _ctx.SaveChanges();

                return Ok();
            }


        }
    }

}

