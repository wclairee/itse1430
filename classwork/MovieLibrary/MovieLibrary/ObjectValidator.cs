using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    public static class ObjectValidator
    {
       // private ObjectValidator() { }

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

        //private int _unused;
    }
}
