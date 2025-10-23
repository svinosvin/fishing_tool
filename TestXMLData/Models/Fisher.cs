using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLData.Models
{
    public class Fisher
    {
        public string FIO {  get; set; }
        public List<Tour>? Tours { get; set; } = new List<Tour>();


        public Fisher() { }
        public Fisher(string FIO) { this.FIO = FIO; }
    }
}
