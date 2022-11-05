namespace ContactManager
{

    /// <summary>Provides a database for contacts.</summary>
    public interface IContactDatabase
    {
        /// <summary>
        /// Adds a contact to the database.</summary>
        /// <param name="contact">The movie to add.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The created contact.</returns>
        Contact Add ( Contact contact, out string errorMessage );

        /// <summary>
        /// Gets a particular contact.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public Contact Get ( Contact contact, out string errorMessage );

        public IEnumerable<Contact> GetAll ();

        public void Remove ( int id );

        public bool Contact ( int id, Contact contact, out string errorMessage );

    }
}
