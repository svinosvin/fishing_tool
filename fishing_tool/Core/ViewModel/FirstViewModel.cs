using DevExpress.Mvvm;
using fishing_tool.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestXMLData.Models;

namespace fishing_tool.Core.ViewModel
{
    public class FirstViewModel: BindableBase, ISingleton
    {
        private readonly CompetitionService _competitionService;
        public Competition Competition { get; set; }

        public FirstViewModel(CompetitionService competitionService) { 
        
            _competitionService = competitionService ; 
        }

        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Fisher> Fishers { get; set; }

        public int SelectedIndex { get; set; }
        public bool DataMode1 => SelectedIndex == 0 ? true: false;
        public bool DataMode2 => SelectedIndex == 1 ? true : false;



        public ICommand GetCompetition => new DelegateCommand(() =>
        {
             Competition = _competitionService.GetCompetition();
             Teams = new ObservableCollection<Team>(Competition.Teams);
             List<Fisher> fishers = new List<Fisher>();
             foreach (var team in Teams) { 
                foreach (var fisher in team.Fishers)
                {
                    fishers.Add(fisher);
                }
            
             }
            Fishers = new ObservableCollection<Fisher>(fishers);
           
        });


    }
}
