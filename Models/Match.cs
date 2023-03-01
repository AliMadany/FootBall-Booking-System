using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M3gogo.Models
{
    public class Match
    {


        public String HostClub { get; set; }

        public String GuestClub { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime endTime { get; set; }

        public String Stadium { get; set; }
    }
}