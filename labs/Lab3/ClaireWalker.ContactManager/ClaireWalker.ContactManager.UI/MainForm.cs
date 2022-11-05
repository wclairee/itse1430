using System;

namespace ClaireWalker.ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
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

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }

        private void OnContactAdd ( object sender, EventArgs e )
        {
            var child = new AddContactForm();

            do
            {
                //Showing form modally
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

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateUI ()
        {
            UpdateUI(false);
        }
        private void UpdateUI ( bool initialLoad )
        {
            var contacts = _contacts.GetAll();

            if (initialLoad &&
                contacts.Any())
            {
                if (Confirm("Do you want to seed some contacts?", "Database Empty"))
                {
                    _contacts.Seed();
                    contacts = _contacts.GetAll();
                };

            };
        }

        private IContactDatabase _contacts = new Memory.MemoryContactDatabase();
    }
}