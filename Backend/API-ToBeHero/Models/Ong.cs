using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ToBeHero.Models
{
    public class Ong
    {
        public int Id { get; set; }
        public int WhatsApp { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }

        public ICollection<Incident> Incidents { get; set; }
    }
}
