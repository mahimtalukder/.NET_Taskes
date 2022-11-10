using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger.Repo;

namespace ZeroHunger.Models
{
    public class CheckEmailAdmin : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                var admin = validationContext.ObjectInstance as AdminData;
                bool isUnique = UserRepo.UniqueEmail(value.ToString(), admin.UserId);
                if (isUnique)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Email alrady exist");
                }

            }
            catch (NullReferenceException ex)
            {
                return new ValidationResult("Date of birth requerd!");
            }
        }

    }
}