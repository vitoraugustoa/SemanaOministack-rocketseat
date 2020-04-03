using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ToBeHero.Context;
using API_ToBeHero.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ToBeHero.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly HeroDbContext _context;
        private readonly IHelpers _helper;

        public ProfileController(HeroDbContext context, IHelpers helper)
        {
            _context = context;
            _helper = helper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                int idOng = _helper.isAuthenticated();
                if (idOng == 0)
                    return Unauthorized();

                var incidents = await _context.Incident.Where(i => i.IdOng == idOng).ToListAsync();
                return Ok(incidents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}