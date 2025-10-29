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

        public string? Description { get; set; }

        public ICollection<Team>? teams { get; set; }

        public ICollection<Team> resultTable()
        {
            if (teams is not null)
            {
                ICollection<Team> resultTeams = teams
                .OrderByDescending(s => s.TeamScore)
                .ToList();

            }

            return null;
        }





    }
}
