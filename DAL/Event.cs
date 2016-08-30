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

        [Required(ErrorMessage ="Event Date is Required")]
        public DateTime EventDate { set; get; }

        public Boolean IsConfirmed { set; get; }

        public int TotalCost { set; get; }


        public List<OrderedCatering> OrderedCaterings { set; get; }
        public List<OrderedFood> OrderedFoods { set; get; }
        public List<OrderedPhotography> OrderedPhotographies { set; get; }
        
        public List<OrderedPlace> OrderedPlaces { set; get; }
        public List<OrderedDecoration> OrderedDecorations { set; get; }


        public Event()
        {
            OrderedCaterings = new List<OrderedCatering>();
            OrderedFoods = new List<OrderedFood>();
            OrderedPhotographies = new List<OrderedPhotography>();
            OrderedPlaces = new List<OrderedPlace>();
            OrderedDecorations = new List<OrderedDecoration>();

        }



    }
}
