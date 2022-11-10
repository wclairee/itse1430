//Claire Walker
//ITSE 1430
//Fall 2022

using System.ComponentModel.DataAnnotations;


namespace ContactManager
{
    /// <summary>Object validating class.</summary>
    public static class ObjectValidator
    {
        /// <summary>Validates the instance. Error message if invalid.</summary>
        /// <param name="instance">The particular instance of the object.</param>
        /// <param name="errorMessage">The outputted error message.</param>
        /// <returns>Returns a true or false if it is valid.</returns>
        public static bool IsValid ( IValidatableObject instance, out string errorMessage )
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
