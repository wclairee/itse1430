﻿//Claire Walker
//ITSE 1430
//Fall 2022

namespace ContactManager
{
    public abstract class ContactDatabase : IContactDatabase
    {
        /// <summary>Adds a contact to the database.</summary>
        /// <param name="contact">The contact to add.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The created contact.</returns>
        public Contact Add ( Contact contact, out string errorMessage )
        {

            if ( contact == null )
            {
                errorMessage = "Contact cannot be null.";
                return null;
            };

            if (!ObjectValidator.IsValid(contact, out errorMessage))
                return null;

            var existing = FindByLastName(contact.LastName);
            if ( existing != null )
            {
                errorMessage = "Last name must be unique.";
                return null;
            };

            contact = AddCore(contact);
            errorMessage = null;
            return contact;
        }

        protected abstract Contact AddCore ( Contact contact );
        
        /// <summary>Gets a particular contact.</summary>
        /// <param name="contact">The contact to get.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The selected contact.</returns>       
        public Contact Get ( int id )
        {
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        protected abstract Contact GetCore ( int id );

        /// <summary>Gets all the contacts.</summary>
        /// <returns> All the contacts.</returns>
        public IEnumerable<Contact> GetAll ()
        {
            return GetAllCore();
        }

        protected abstract IEnumerable<Contact> GetAllCore ();

        /// <summary>Removes a particular contact.</summary>
        /// <param name="id">The numeric contact identifier or ID.</param>
        public void Remove ( int id )
        {
            if (id <= 0)
                return;

            RemoveCore(id);
        }

        protected abstract void RemoveCore ( int id );

        /// <summary>Updates a contact in the database.</summary>
        /// <param name="id">The ID of the contact.</param>
        /// <param name="contact">The new contact information.</param>
        /// <param name="errorMessage">The error message, if any.</param>
        /// <returns>True if successful or false if otherwise.</returns>
        public bool Update ( int id, Contact contact, out string errorMessage )
        {
            if (contact == null)
            {
                errorMessage = "Contact cannot be null.";
                return false;
            };

            if (!ObjectValidator.IsValid(contact, out errorMessage))
                return false;

            var oldContact = GetCore(id);
            if (oldContact == null)
            {
                errorMessage = "Contact does not exist.";
                return false;
            };

            var existing = FindByLastName(contact.LastName);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Last name must be unique.";
                return false;
            };

            UpdateCore(id, contact);
            errorMessage = null;
            return true;
        }

        protected abstract Contact FindByLastName ( string lastName );

        protected abstract void UpdateCore ( int id, Contact contact );
    }
}
