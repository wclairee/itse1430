using ContactManager;
using ContactManager.Memory;

namespace ClaireWalker.ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            //Stop the event
            e.Cancel = true;
        }

        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed(e);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }

        private void OnContactAdd ( object sender, EventArgs e )
        {
            var child = new AddContactForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(child.SelectedContact, out var error) != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Add Failed.");
            } while (true);
        }

        private void OnContactEdit ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            var child = new AddContactForm();
            child.SelectedContact = contact;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Update(contact.Id, child.SelectedContact, out var error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Update Failed.");
            } while (true);
        }

        private void OnContactDelete ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{contact.FirstName} {contact.LastName}'?", "Delete"))
                return;

            _contacts.Remove(contact.Id);
            UpdateUI();
        }


        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string OrderByLastName ( Contact contact )
        {
            return contact.LastName;
        }

        private string OrderByFirstName ( Contact contact )
        {
            return contact.FirstName;
        }

        private Contact GetSelectedContact ()
        {
            return _lstContacts.SelectedItem as Contact;
        }


        private void UpdateUI ()
        {
            UpdateUI(false);
        }
        private void UpdateUI ( bool initialLoad )
        {
            var contacts = _contacts.GetAll();

            if (initialLoad &&
                !contacts.Any())
            {
                if (Confirm("Do you want to seed some contacts?", "Database Empty"))
                {
                    _contacts.Seed();
                    contacts = _contacts.GetAll();
                };

            };

            _lstContacts.Items.Clear();

            var items = contacts.OrderBy(OrderByLastName)
                           .ThenBy(OrderByFirstName)
                           .ToArray();

            _lstContacts.Items.AddRange(items);
        }

        private IContactDatabase _contacts = new MemoryContactDatabase();
    }
}