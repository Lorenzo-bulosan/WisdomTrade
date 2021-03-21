using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CovidJournal.Models
{
    public class DateMoreThanEqualToday : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Date should not be in the past";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            if (dateValue.Date < DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }

    // TO BE IMPLEMENTED
    public class TickerExist : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Ticker does not exist on Nasdaq";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            // To implement
            
            return ValidationResult.Success;
        }
    }
}
