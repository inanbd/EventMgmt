using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.CustomAttr
{
    public class FoodNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as Food;
            if (owner == null) return new ValidationResult("Model is empty");
            EMDbContext db = new EMDbContext();
            var food = db.Foods.FirstOrDefault(f => f.FoodTitle == (string)value && f.FoodId != owner.FoodId);

            if (food == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Food title already exists");
        }
    }
}
