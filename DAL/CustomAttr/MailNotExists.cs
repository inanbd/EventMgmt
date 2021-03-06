﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.CustomAttr
{
    public class MailNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as User;
            if (owner == null) return new ValidationResult("Model is empty");
            EMDbContext db = new EMDbContext();
            var user = db.Users.FirstOrDefault(u => u.Email == (string)value && u.UserId != owner.UserId);

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Mail already exists");
        }
    }
}
