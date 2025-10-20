using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_tool.Core.Model
{
    public enum Zones { A, B, C, D, E, F, G, H }

    public class Tour
    {

        public int Id { get; set; }

        public Fisher Fisher { get; set; }

        public Zones Zone {  get; set; }

        public double Weight {  get; set; }

        
    }
}
