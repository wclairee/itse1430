namespace ContactManager
{
    public static class ContactDatabaseExtensions
    {
        public static void Seed ( this IContactDatabase database )
        {
            var contacts = new Contact[] {
                new Contact() {
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bobsmith@yahoo.com",
                    Notes = "",
                    IsFavorite = true,
                },
                new Contact() {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe01@yahoo.com",
                    Notes = "",
                    IsFavorite = true,
                },
                new Contact() {
                    FirstName = "Jane",
                    LastName = "Goodall",
                    Email = "ilovemonkeys@gmail.com",
                    Notes = "",
                    IsFavorite = true,
                }
            };

            foreach (var contact in contacts)
                database.Add(contact, out var error);
        }
    }
}
