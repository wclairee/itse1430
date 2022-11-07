namespace ContactManager.Memory
{
    public class MemoryContactDatabase : ContactDatabase
    {
        protected override Contact AddCore ( Contact contact )
        {
            contact.Id = _id++;
            _contacts.Add(contact.Clone());

            return contact;
        }

        protected override Contact GetCore ( int id )
        {
            foreach (var contact in _contacts)
                if (contact?.Id == id)
                    return contact.Clone();

            return null;
        }

        protected override IEnumerable<Contact> GetAllCore ()
        {
            foreach (var contact in _contacts)
            {
                yield return contact.Clone();
            };
        }

        protected override void RemoveCore ( int id )
        {
            //Enumerate array looking for match
            for (var index = 0; index < _contacts.Count; ++index)
                if (_contacts[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _contacts.RemoveAt(index);
                    return;
                };
        }

        protected override void UpdateCore ( int id, Contact contact )
        {
            var oldContact = FindByID(id);
            contact.CopyTo(oldContact);
            oldContact.Id = id;
        }

        private Contact FindByID ( int id )
        {
            foreach (var contact in _contacts)
                if (contact.Id == id)
                    return contact;

            return null;
        }

        protected override Contact FindByLastName ( string lastName )
        {
            foreach (var contact in _contacts)
                if (String.Equals(contact.LastName, lastName, StringComparison.OrdinalIgnoreCase))
                    return contact;

            return null;
        }

        private int _id = 1;
        private List<Contact> _contacts = new List<Contact>();
    }
}
