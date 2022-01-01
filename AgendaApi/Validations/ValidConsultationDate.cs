using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Validations
{
    public class ValidConsultationDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = (DateTime) value;
            
            return date.Hour is >= 8 and <= 18
                   && date.Minute is 0 or 30
                   && date.Second is 0
                   && date.Millisecond is 0;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return IsValid(value) ? ValidationResult.Success : new ValidationResult("The date should be between 8H00 and 18H00, with 30 minutes intervals (e.g. 10H30)");
        }
    }
}