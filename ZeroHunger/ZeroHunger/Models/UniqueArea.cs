using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger.Repo;

namespace ZeroHunger.Models
{
    public class UniqueArea : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                var area = validationContext.ObjectInstance as AreaModel;
                bool isUnique = AreaRepo.IsUnique((string)value, area.Id);
                if (isUnique)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Area alrady exist");
                }

            }
            catch (NullReferenceException ex)
            {
                return new ValidationResult("Date of birth requerd!");
            }
        }

    }
}