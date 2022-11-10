using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger.Repo;

namespace ZeroHunger.Models
{
    public class CheckEmailEmployee : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                var employee = validationContext.ObjectInstance as EmployeeData;
                bool isUnique = UserRepo.UniqueEmail(value.ToString(), employee.UserId);
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