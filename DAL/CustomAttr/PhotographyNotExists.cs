using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.CustomAttr
{
    public class PhotographyNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as Photography;
            if (owner == null) return new ValidationResult("Model is empty");
            EMDbContext db = new EMDbContext();
            var user = db.Photographies.FirstOrDefault(ph => ph.PhotographyTitle == (string)value && ph.PhotographyId != owner.PhotographyId);

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Title already exists");
        }
    }
}
