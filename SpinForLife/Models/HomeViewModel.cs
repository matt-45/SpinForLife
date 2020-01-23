using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class HomeViewModel
    {
        public ApplicationUser User { get; set; }
        public Event Event { get; set; }
        public bool UserIsAdmin { get; set; }
        public List<List<ReservedBike>> Grid { get; set; }
        public List<Team> AllTeams { get; set; }
    }
}