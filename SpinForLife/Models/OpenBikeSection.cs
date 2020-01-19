using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class OpenBikeSection
    {
        public int Id { get; set; }

        public int NumberOfSlots { get; set; }
        public string Interval { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [NotMapped]
        public int OpenSlots
        {
            get
            {
                return NumberOfSlots - Riders.Count();
            }
        }

        public virtual ICollection<ApplicationUser> Riders { get; set; }

        public OpenBikeSection()
        {
            Riders = new HashSet<ApplicationUser>();
        }

    }
}