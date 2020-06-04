using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ToBeHero.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ToBeHero.Controllers
{
    [Route("sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly HeroDbContext _context;

        public SessionController(HeroDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(int idOng)
        {
            try
            {
                var ong = await _context.Ong.Where(i => i.Id == idOng).FirstOrDefaultAsync();
                if(ong == null)    
                    return BadRequest("No ONG found with this ID.");

                return Ok(ong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}