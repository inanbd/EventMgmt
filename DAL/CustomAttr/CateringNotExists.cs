using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.CustomAttr
{
    public class CateringNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as Catering;
            if (owner == null) return new ValidationResult("Model is empty");
            EMDbContext db = new EMDbContext();
            var user = db.Caterings.FirstOrDefault(cat => cat.CateringTitle == (string)value && cat.CateringId != owner.CateringId);

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Title already exists");
        }
    }
}
