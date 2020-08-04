using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_ToBeHero.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int IdOng { get; set; }
        
        [JsonIgnore]
        public Ong IncidentOng { get; set; }
    }
}
