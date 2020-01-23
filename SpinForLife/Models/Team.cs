using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int? ReservedBikeId { get; set; }
        public virtual ReservedBike ReservedBike { get; set; }

        public virtual ICollection<ApplicationUser> Riders { get; set; }

        [NotMapped]
        public bool HasBike {
            get
            {
                if (ReservedBikeId == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Team()
        {
            Riders = new HashSet<ApplicationUser>();
        }
    }
}