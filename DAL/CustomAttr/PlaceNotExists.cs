using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.CustomAttr
{
    public class PlaceNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as Place;
            if (owner == null) return new ValidationResult("Model is empty");
            EMDbContext db = new EMDbContext();
            var user = db.Places.FirstOrDefault(p => p.PlaceTitle == (string)value && p.PlaceId != owner.PlaceId);

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Place already exists in Database");
        }
    }
}
