using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class ReservedBike
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public int Id { get; set; }

        public bool HasTeam { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        [NotMapped]
        public Team Team
        {
            get
            {
                return Teams.FirstOrDefault();
            }
        }
        
        public ReservedBike()
        {
            Teams = new HashSet<Team>();
        }

        public void AddTeam(Team team)
        {
            Teams.Clear();
            Teams.Add(team);
        }
    }
}