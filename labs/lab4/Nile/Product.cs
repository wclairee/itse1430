/*
 * ITSE 1430
 */
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    public class Product //: IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        [Range(0, Int32.MaxValue)]
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return Name;
        }

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    var errors = new List<ValidationResult>();

        //    if (Id < 0)
        //        errors.Add(new ValidationResult("Id must be greater than or equal to 0.", new[] { nameof(Id) }));

        //    if (Name == null)
        //        errors.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));

        //    if (Price < 0)
        //        errors.Add(new ValidationResult("Price must be greater than or equal to 0.", new[] { nameof(Price) }));

        //    return errors;
        //}

        #region Private Members

        private string _name;
        private string _description;
        #endregion
    }
}
