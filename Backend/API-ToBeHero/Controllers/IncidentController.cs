using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ToBeHero.Context;
using API_ToBeHero.Helper;
using API_ToBeHero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace API_ToBeHero.Controllers
{
    [Route("incidents")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly HeroDbContext _context;
        private readonly IHelpers _helper;

        public IncidentController(HeroDbContext context, IHelpers helper)
        {
            _context = context;
            _helper = helper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            try
            {
                int ongId = _helper.isAuthenticated();
                if (ongId == 0)
                    return Unauthorized();

                int count = await _context.Incident.Where(i => i.IdOng == ongId).CountAsync();
                Response.Headers.Add("X-Total-Count", count.ToString());
                return Ok(await _context.Ong.Include(i => i.Incidents).Where(i => i.Id == ongId).Select(e => e.Incidents.Skip((page - 1) * 3).Take(3)).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Teste")]
        public async Task<IActionResult> Teste()
        {
            try
            {
                return Ok(await  _context.Ong.Include(i => i.Incidents).ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(Incident incident)
        {
            try
            {
                int idOng = _helper.isAuthenticated();
                if (idOng == 0)
                    return Unauthorized();

                incident.IdOng = idOng;
                _context.Incident.Add(incident);
                await _context.SaveChangesAsync();

                return Ok(new { incident.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Incident incident)
        {
            try
            {
                _context.Incident.Attach(incident);
                await _context.SaveChangesAsync();

                return Ok(incident);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                Incident incident = await _context.Incident.FindAsync(id);

                if (incident == null)
                    return NotFound("Incident not found.");

                if (incident.IdOng != _helper.isAuthenticated())
                    return Unauthorized("Operation not permitte.");

                _context.Incident.Remove(incident);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}