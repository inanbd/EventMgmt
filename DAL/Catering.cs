﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.CustomAttr;

namespace DAL
{
    public class Catering
    {
        [Key]
        public int CateringId { set; get; }


        [Required(ErrorMessage = "Title for Catering is Required")]
        [MaxLength(60, ErrorMessage = "Title have to be in 60 charecters")]
        public String CateringTitle { set; get; }


        public String CateringCategory { set; get; }


        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(500, ErrorMessage = "Description have to be in 500 charecters")]
        public String CateringDescription { set; get; }


        [Required(ErrorMessage = "Catering Cost Required")]
        public double CateringCost { set; get; }


        public String pic1 { set; get; }
        public String pic2 { set; get; }
        public String pic3 { set; get; }
        public String pic4 { set; get; }
        public String pic5 { set; get; }
    }
}
