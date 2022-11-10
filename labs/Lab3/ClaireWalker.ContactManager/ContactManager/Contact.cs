//Claire Walker
//ITSE 1430
//Fall 2022

using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace ContactManager
{
    /// <summary>Represents a contact.</summary>
    public class Contact : IValidatableObject 
    {
        /// <summary>Gets or sets the unique ID for the contact.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the first name of the particular contact.</summary>
        public string FirstName 
        {
            get 
            {
                return _firstName ?? "";
            }
            set 
            {
                _firstName = value?.Trim() ?? "";
            }
        }
        private string _firstName;

        /// <summary>Gets or sets the first name of the particular contact.</summary>
        public string LastName
        {
            get 
            {
                return _lastName ?? "";
            }
            set 
            {
                _lastName = value?.Trim() ?? "";
            }
        }
        private string _lastName;

        /// <summary>Gets or sets the email of the particular contact.</summary>
        public string Email
        {
            get 
            {
                return _email ?? "";
            }
            set 
            {
                if (IsValidEmail( value))
                    _email = value?.Trim() ?? "";
            }
        }
        private string _email;

        /// <summary>Gets or sets the notes about the particular contact.</summary>
        public string Notes
        {
            get 
            {
                return _notes ?? "";
            }
            set 
            {
                _notes = value?.Trim() ?? "";
            }
        }
        private string _notes;

        /// <summary>Gets or sets if the particular contact is a favorite.</summary>
        public bool IsFavorite { get; set; }

        /// <summary>Overrides ToString to return the first name, last name,
        /// and the email of the particular contact.</summary>
        /// <returns>First name, last name, and email of contact.</returns>
        public override string ToString ()
        {
            var str = base.ToString();
            var contactinfo = $"{LastName}, {FirstName} \t\t\t {Email}";
            return contactinfo;
        }

        /// <summary>Verifies the email is valid.</summary>
        /// <param name="source">The email string being validated.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public bool IsValidEmail ( string source )
        {
            return MailAddress.TryCreate(source, out var address);
        }

        /// <summary>Validates the last name and the email.</summary>
        /// <param name="validationContext">The context in which the validation is performed.</param>
        /// <returns>The errors.</returns>
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            if (LastName.Length == 0)
                errors.Add(new ValidationResult("Last name is required.", new[] { nameof(LastName) }));

            if (Email.Length == 0)
                errors.Add(new ValidationResult("Email is required.", new[] { nameof(Email) }));

            return errors; 

        }

        /// <summary>Clones the contact.</summary>
        /// <returns>The copied contact.</returns>
        public Contact Clone ()
        {
            var contact = new Contact ();
            CopyTo(contact);

            return contact;
        }

        /// <summary>Copies the contact.</summary>
        /// <param name="contact">The contact to be copied.</param>
        public void CopyTo ( Contact contact )
        {
            contact.Id = Id;
            contact.FirstName = FirstName;
            contact.LastName = LastName;
            contact.Email = Email;
            contact.Notes = Notes;
            contact.IsFavorite = IsFavorite;
        }
    }

}