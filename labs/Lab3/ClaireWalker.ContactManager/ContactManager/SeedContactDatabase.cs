//Claire Walker
//ITSE 1430
//Fall 2022

namespace ContactManager
{
    public static class ContactDatabaseExtensions
    {
        /// <summary>Seeds contacts into the database and list on loading.</summary>
        /// <param name="database">The contact database.</param>
        public static void Seed ( this IContactDatabase database )
        {
            var contacts = new Contact[] {
                new Contact() {
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    Email = "lordoftheshire@yahoo.com",
                    Notes = "hobbit",
                    IsFavorite = true,
                },
                new Contact() {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe01@yahoo.com",
                    Notes = "",
                    IsFavorite = false,
                },
                new Contact() {
                    FirstName = "Jane",
                    LastName = "Goodall",
                    Email = "ilovemonkeys@gmail.com",
                    Notes = "Award winning scientist and author.",
                    IsFavorite = true,
                },
                new Contact() {
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Email = "notbatman@wayneenterprises.com",
                    Notes = "Batman.",
                    IsFavorite = true,
                }
            };

            foreach (var contact in contacts)
                database.Add(contact, out var error);
        }
    }
}
