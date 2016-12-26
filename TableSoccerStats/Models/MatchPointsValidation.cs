using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TableSoccerStats.Models
{
    public class MatchPointsValidation : ValidationAttribute
    {
        private readonly string _otherPropertyName;
        public MatchPointsValidation(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (property == null)
            {
                return new ValidationResult(string.Format(
                    CultureInfo.CurrentCulture,
                    "Unknown property {0}",
                    new[] { _otherPropertyName }
                ));
            }
            var otherPropertyValue = property.GetValue(validationContext.ObjectInstance, null);
            if (((int)value != 10 && (int)otherPropertyValue != 10) || (int)value == (int)otherPropertyValue)
            {
                return new ValidationResult("Assigned points does not indicate which team is a winner. Winner should have 10 points");
            }

            return null;
        }
    }
}