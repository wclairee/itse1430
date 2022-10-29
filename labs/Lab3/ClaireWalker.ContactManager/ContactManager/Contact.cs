using System.Net.Mail;

namespace ContactManager
{
    public class Contact
    {
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

        public string Email
        {
            get 
            {
                return _email ?? "";
            }
            set 
            {
                _email = value?.Trim() ?? "";
            }
        }
        private string _email;

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

        public bool IsFavorite { get; set; }

        public bool IsValidEmail ( string source )
        {
            return MailAddress.TryCreate(source, out var address);
        }
    }

}