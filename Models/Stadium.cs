using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace M3gogo.Models
{

    [Table("Stadium")]
    public class Stadium
    {

        [Key]

        public int stId { get; set; }

        public String Name { get; set; }

        public String Location { get; set; }
        public int Capacity { get; set; }
        
    }

  




    }



