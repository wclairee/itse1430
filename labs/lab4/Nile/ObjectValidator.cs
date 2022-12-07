/*
 * Claire Walker
 * ITSE 1430
 * Fall 2022
 */
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    public static class ObjectValidator
    {
            public static bool IsValid ( object instance, out string errorMessage )
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

            public static void Validate ( object instance )
            {
                Validator.ValidateObject(instance, new ValidationContext(instance), true);
            }
    }
}
