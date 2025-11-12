using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLData.Models
{
    public class Fisher
    {
        
        public string TeamName { get; set; }
        public string FIO {  get; set; }
        public List<Tour>? Tours { get; set; } = new List<Tour>();

        public double Score => Tours.Sum(s=> s.Weight) ?? 0;

        public Fisher() { }
        public Fisher(string FIO) { this.FIO = FIO; }
    }
}
