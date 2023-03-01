using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M3gogo.Models
{
    public class AM

   {

        [Key]
        public int amId { get; set; }

        [Required(ErrorMessage ="Please enter name")]

        public String name{ get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public String username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public String password { get; set; }
    }
}