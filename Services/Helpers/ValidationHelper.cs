﻿using System.ComponentModel.DataAnnotations;

namespace Services.Helpers
{
    internal class ValidationHelper
    {
        internal static void ModelValidation(object obj)
        {
            //Model validations
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            //validate the model object and get errors
            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
