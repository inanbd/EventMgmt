using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Place
    {
        [Key]
        public int PlaceId { set; get; }

        [Required(ErrorMessage = "Place name must be Required")]
        [MaxLength(60, ErrorMessage = "Name have to be in 60 charecters")]
        public String PlaceTitle { set; get; }


        public String PlaceCategory { set; get; }


        [Required(ErrorMessage = "Place description must be Required")]
        [MaxLength(500, ErrorMessage = "Description have to be in 500 charecters")]
        public String PlaceDescription { set; get; }


        [Required(ErrorMessage = "Place Cost Required")]
        public double PlaceCost { set; get; }

        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }

    }
}
