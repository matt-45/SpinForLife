using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class ReservedBike
    {
        public int Id { get; set; }

        public bool HasTeam { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual Team Team { get; set; }
    }
}