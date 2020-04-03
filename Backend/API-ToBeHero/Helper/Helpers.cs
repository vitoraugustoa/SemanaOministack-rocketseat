using API_ToBeHero.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ToBeHero.Helper
{
    public class Helpers : IHelpers
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HeroDbContext _context;

        public Helpers(IHttpContextAccessor httpContextAccessor, HeroDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public int isAuthenticated()
        {
            var headers = _httpContextAccessor.HttpContext.Request.Headers;
            if (!headers.TryGetValue("Authorization", out StringValues idOngLogged))
                return 0;

            int idOng = Convert.ToInt32(idOngLogged.FirstOrDefault());

            if (_context.Ong.Find(idOng) == null)
                return 0;

            return idOng;
        }
    }
}
