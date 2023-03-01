using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M3gogo.Models
{
    public class Fan
    {
        public String name { get; set; }

        [Required(ErrorMessage = "Please enter username")]

        public String username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]

        public String password { get; set; }


        public String nationalId { get; set; }
        public int phoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public String Adress { get; set; }



        // for ticket purchase
        public String host_club { get; set; }
        public String guest_club { get; set; }
        public DateTime start_time { get; set; }

    }
}