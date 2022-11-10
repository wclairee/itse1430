//Claire Walker
//ITSE 1430
//Fall 2022

namespace ContactManager
{

    /// <summary>Provides a database interface for managing contacts.</summary>
    public interface IContactDatabase
    {
        /// <summary>Adds a contact to the database.</summary>
        /// <param name="contact">The contact to add.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The created contact.</returns>
        Contact Add ( Contact contact, out string errorMessage );

        /// <summary>Gets a particular contact.</summary>
        Contact Get ( int id );

        /// <summary>Gets all the contacts.</summary>
        /// <returns>All of the contacts.</returns>
        IEnumerable<Contact> GetAll ();

        /// <summary>Removes a particular contact.</summary>
        /// <param name="id"></param>
        void Remove ( int id );

        /// <summary>Updates a particular contact in the database.</summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <param name="errorMessage"></param>
        /// <returns>A boolean.</returns>
        bool Update ( int id, Contact contact, out string errorMessage );

    }
}
