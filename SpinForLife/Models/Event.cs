using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class Event
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Enter in a number of rows.")]
        [Display(Name = "Number of rows for reserved bikes.")]
        public int Rows { get; set; }

        [Required(ErrorMessage = "Enter in a number of columns.")]
        [Display(Name = "Number of columns for reserved bikes.")]
        public int Columns { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public string IntervalsString { get; set; }

        public virtual ICollection<OpenBikeSection> OpenBikeSections { get; set; }
        public virtual ICollection<ReservedBike> ReservedBikes { get; set; }

        [NotMapped]
        public List<Team> Teams
        {
            get
            {
                return ReservedBikes.Where(b => b.HasTeam).Select(b => b.Team).ToList();
            }
        }
        
        [NotMapped]
        public List<string> Intervals
        {
            get
            {
                return IntervalsString.Split(',').ToList();
            }
        }

        [NotMapped]
        public List<List<ReservedBike>> Grid
        {
            get
            {
                var grid = new List<List<ReservedBike>>();
                for (int i = 0; i < this.Rows; i++)
                {
                    var row = new List<ReservedBike>();
                    for (int x = 0; x < this.Columns; x++)
                    {
                        row.Add(this.ReservedBikes.Where(b => b.Row == i).FirstOrDefault(b => b.Column == x));
                    }
                    grid.Add(row);
                }
                return grid;
            }
        }

        public Event()
        {
            OpenBikeSections = new HashSet<OpenBikeSection>();
            ReservedBikes = new HashSet<ReservedBike>();
        }
    }
}