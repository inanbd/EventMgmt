using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderedPlace
    {
        [Key]
        public int OPlaceId { get; set; }

        public int PlaceId { set; get; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }


        public String PlaceTitle { set; get; }

        public String PlaceCategory { set; get; }

        public String PlaceDescription { set; get; }


        public double PlaceCost { set; get; }
        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }
    }
}
