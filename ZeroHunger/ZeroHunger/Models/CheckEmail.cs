using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger.Repo;

namespace ZeroHunger.Models
{
    public class CheckEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                if(value == null)
                {
                    return new ValidationResult("Email requerd");
                }
                bool isUnique = UserRepo.UniqueEmail(value.ToString(), 0);
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