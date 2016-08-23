using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Login
    {
        [Required(ErrorMessage ="Username Required")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }
    }
}
