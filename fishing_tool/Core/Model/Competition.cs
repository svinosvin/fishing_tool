using DevExpress.Mvvm;
using fishing_tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLData.Models
{
     public class Competition : BindableBase
    {
        public int? Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public ICollection<Team>? Teams { get; set; }

        public ICollection<Team> resultTable()
        {
            if (Teams is not null)
            {
                ICollection<Team> resultTeams = Teams
                .OrderByDescending(s => s.TeamScore)
                .ToList();
                return resultTeams;
            }
            return null;
        }





    }
}
