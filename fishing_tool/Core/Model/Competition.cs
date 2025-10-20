using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_tool.Core.Model
{
    public class Competition
    {   
        public int Id { get; set; }
        public string Name {  get; set; }

        public ICollection<Tour> tours { get; set; }

        public string Date {  get; set; }
    }
}
