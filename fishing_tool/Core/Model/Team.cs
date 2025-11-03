using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLData.Models
{
    public class Team
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public List<Fisher>? Fishers { get; set; } = new List<Fisher>();
        public double TeamScore => Fishers.Sum(s => s.Score);
          
        
        public Team() { }
        public Team(string name)
        {
            Name = name;
        }
    }
}
