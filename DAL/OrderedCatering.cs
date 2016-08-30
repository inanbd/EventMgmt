using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderedCatering
    {
        [Key]
        public int OCateringId { get; set; }

        public int CateringId { set; get; }
        
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        public String CateringTitle { set; get; }

        public String CateringCategory { set; get; }

        public String CateringDescription { set; get; }

        public int NoOfCaterers { set; get; }


        public double CateringCost { set; get; }
        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }

    }
}
