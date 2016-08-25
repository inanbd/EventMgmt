using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventMgmt.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username Required")]
        public string Username { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Passsword Required")]
        public string Password { set; get; }
    }
}