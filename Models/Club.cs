using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace M3gogo.Models
{

    [Table("Club")]
    public class Club // table
    {
      
        public int ClubID { get; set; }
        public String Name { get; set; }

        public String Location { get; set; }

    }
}