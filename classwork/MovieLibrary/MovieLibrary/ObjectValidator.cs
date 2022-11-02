﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    public class ObjectValidator
    {
        public bool IsValid ( IValidatableObject instance, out string errorMessage )
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
            {
                errorMessage = results[0].ErrorMessage;
                return false;
            };

            errorMessage = null;
            return true;
        }
    }
}
