using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SwiggyAppAPI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
     //   [Required (ErrorMessage= "Please Enter Name")]
        public string Name { get; set; }
      //  [Required]
        public string Address { get; set; }
      //  [Required]
       // [MaxLength(10)]
       // [MinLength(10)]
        public int MobileNo { get; set; }
    }
}
