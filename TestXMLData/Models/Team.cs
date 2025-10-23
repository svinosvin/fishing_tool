﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLData.Models
{
    public class Team
    {
        
        public string? Name { get; set; }
        public List<Fisher>? Fishers { get; set; } = new List<Fisher>();

        public Team() { }
        public Team(string name)
        {
            Name = name;
        }
    }
}
