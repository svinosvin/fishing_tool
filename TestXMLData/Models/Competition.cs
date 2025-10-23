using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLData.Models
{
    public class Competition
    {
        public int? Id { get; set; }
        public string? Title { get; set; }

        public ICollection<Team>? teams { get; set; }
    }
}
