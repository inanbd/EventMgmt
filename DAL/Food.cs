using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Food
    {
        [Key]
        public int FoodId { set; get; }


        [Required(ErrorMessage ="Food name must be Required")]
        [MaxLength(60, ErrorMessage = "Name have to be in 60 charecters")]
        public String FoodTitle { set; get; }


        public String FoodCategory { set; get; }


        [Required(ErrorMessage = "Food description must be Required")]
        [MaxLength(500,ErrorMessage ="Description have to be in 500 charecters")]
        public String FoodDescription { set; get; }


        [Required(ErrorMessage = "Food Cost Required")]
        public double FoodCost { set; get; }


        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }




    }
}
