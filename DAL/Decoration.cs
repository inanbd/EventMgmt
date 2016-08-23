using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Decoration
    {
        [Key]
        public int DecorationId { set; get; }


        [Required(ErrorMessage = "Decoration title must be Required")]
        [MaxLength(60, ErrorMessage = "Title have to be in 60 charecters")]
        public String DecorationTitle { set; get; }


        public String DecorationCategory { set; get; }


        [Required(ErrorMessage = "Decoration description must be Required")]
        [MaxLength(250, ErrorMessage = "Description have to be in 250 charecters")]
        public String DecorationDescription { set; get; }


        [Required(ErrorMessage = "Decoration Cost Required")]
        public double DecorationCost { set; get; }


        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }


    }
}
