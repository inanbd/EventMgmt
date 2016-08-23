using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Photography
    {
        [Key]
        public int PhotographyId { set; get; }


        [Required(ErrorMessage = "Photography title must be Required")]
        [MaxLength(60, ErrorMessage = "Title have to be in 60 charecters")]
        public String PhotographyTitle { set; get; }
        


        [Required(ErrorMessage = "Photography description must be Required")]
        [MaxLength(500, ErrorMessage = "Description have to be in 500 charecters")]
        public String PhotographyDescription { set; get; }


        [Required(ErrorMessage = "Cost Required")]
        public double PhotographyCost { set; get; }

        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }

    }
}
