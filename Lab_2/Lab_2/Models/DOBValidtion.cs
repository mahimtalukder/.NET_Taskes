using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_2.Models
{
    public class DOBValidtion
    {

        public class DOBDateValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime date;
                bool parsed = DateTime.TryParse(value.ToString(), out date);
                if (!parsed)
                    return new ValidationResult("Invalid Date");
                else
                {
                    //change below as per requirement
                    var min = DateTime.Now.AddYears(-18); //for min 18 age
                    var msg = string.Format("Minimum age limite is 18", min);
                    try
                    {
                        if (date > min)
                            return new ValidationResult(msg);
                        else
                            return ValidationResult.Success;
                    }
                    catch (Exception e)
                    {
                        return new ValidationResult(e.Message);
                    }
                }
            }
        }
    }
}