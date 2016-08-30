using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderedDecoration
    {
        [Key]
        public int ODecorationId { get; set; }

        public int DecorationId { set; get; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }


        public String DecorationTitle { set; get; }

        public String DecorationCategory { set; get; }

        public String DecorationDescription { set; get; }


        public double DecorationCost { set; get; }
        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }
    }
}
