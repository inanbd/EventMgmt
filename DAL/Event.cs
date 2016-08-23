using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Event
    {
        [Key]
        public int EventId { set; get; }

        [Required]
        public int UserId { set; get; }

        [ForeignKey("UserId")]
        public User user { set; get; }


        [Required(ErrorMessage ="Event Name is Required")]
        public String EventTitle { set; get; }

    }
}
