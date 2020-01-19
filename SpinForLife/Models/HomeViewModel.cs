using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpinForLife.Models
{
    public class HomeViewModel
    {
        public Event Event { get; set; }
        public List<List<ReservedBike>> Grid { get; set; }
    }
}