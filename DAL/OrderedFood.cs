using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderedFood
    {
        [Key]
        public int OFoodId { get; set; }

        public int FoodId { set; get; }
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }


        public String FoodTitle { set; get; }

        public String FoodCategory { set; get; }

        public String FoodDescription { set; get; }

        [Required(ErrorMessage ="Amount Required")]
        public int Amount { get; set; }

        public double FoodCost { set; get; }
        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }

    }
}
