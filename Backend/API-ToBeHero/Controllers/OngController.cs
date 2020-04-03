using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ToBeHero.Context;
using API_ToBeHero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ToBeHero.Helper;

namespace API_ToBeHero.Controllers
{
    [Route("ongs")]
    [ApiController]
    public class OngController : ControllerBase
    {
        private readonly HeroDbContext _context;

        public OngController(HeroDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _context.Ong.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(Ong ong)
        {
            try
            {
                Random random = new Random();
                ong.Id = random.Next(0, int.MaxValue);
                _context.Ong.Add(ong);
                await _context.SaveChangesAsync();

                return Ok(ong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Ong ong)
        {
            try
            {
                _context.Ong.Attach(ong);
                await _context.SaveChangesAsync();

                return Ok(ong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Ong ong = await _context.Ong.FindAsync(id);
                _context.Ong.Remove(ong);
                await _context.SaveChangesAsync();

                return Ok(ong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}