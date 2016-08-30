using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventMgmt.Models
{
    public class FoodViewModel
    {
        public int FoodId { set; get; }
        public string FoodTitle { set; get; }

        public double FoodPrice { set; get; }

        public int FoodAmount { set; get; }

    }
}