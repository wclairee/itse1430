using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactManager;

using Microsoft.VisualBasic.Devices;

namespace ClaireWalker.ContactManager.UI
{
    public partial class AddContactForm : Form
    {
        public AddContactForm ()
        {
            InitializeComponent();
        }

        public Contact SelectedContact { get; set; }

        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var btn = sender as Button;

            var contact = new Contact();
            contact.FirstName = _txtFirstName.Text;
            contact.LastName = _txtLastName.Text;
            contact.Email = _txtEmail.Text;
            contact.Notes = _txtNotes.Text;
            contact.IsFavorite = _chkIsFavorite.Checked;

            if (!ObjectValidator.IsValid(contact, out var error))
            {
                DisplayError(error, "Save");
                return;
            };

            SelectedContact = contact;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnValidateLastName ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //Not valid
                _errors.SetError(control, "Last name is required.");
                e.Cancel = true;
            } else
            {
                //Valid
                _errors.SetError(control, "");
            };
        }

        private void OnValidateEmail ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (IsValidEmail(control.Text))
            {
                //Not valid
                _errors.SetError(control, "Email is required.");
                e.Cancel = true;
            } else
            {
                //Valid
                _errors.SetError(control, "");
            };
        }

        public bool IsValidEmail ( string source )
        {
            return MailAddress.TryCreate(source, out var address);
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (SelectedContact != null)
            {
                _txtFirstName.Text = SelectedContact.FirstName;
                _txtLastName.Text = SelectedContact.LastName;
                _txtEmail.Text = SelectedContact.Email;
                _txtNotes.Text = SelectedContact.Notes;

                _chkIsFavorite.Checked = SelectedContact.IsFavorite;
            };

            ValidateChildren();
        }
    }
}
