using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class Team
    {
        [ForeignKey("ReservedBike")]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ReservedBike ReservedBike { get; set; }

        public ICollection<ApplicationUser> Riders { get; set; }

        public Team()
        {
            Riders = new HashSet<ApplicationUser>();
        }
    }
}