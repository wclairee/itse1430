namespace ContactManager.Memory
{
    public class MemoryContactDatabase : ContactDatabase
    {
        protected override Contact AddCore ( Contact contact )
        {
            contact.Id = _id++;
            _contacts.Add(contact.Clone());
        }

        private int _id;
        private List<Contact> _contacts = new List<Contact> ();
    }
}
