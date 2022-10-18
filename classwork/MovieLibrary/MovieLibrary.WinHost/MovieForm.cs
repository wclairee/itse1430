using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        /// <summary>Gets or sets the movie being edited.</summary>
        public Movie SelectedMovie { get; set; }

        protected override void OnLoad ( EventArgs e)
        {
            base.OnLoad(e);

            //Do any init just before UI is rendered
            if (SelectedMovie != null)
            {
                //Load UI
                _txtTitle.Text = SelectedMovie.Title;
                _txtDescription.Text = SelectedMovie.Description;
                _cbRating.Text = SelectedMovie.Rating;

                _chkIsClassic.Checked = SelectedMovie.IsClassic;
                _txtRunLength.Text = SelectedMovie.RunLength.ToString();
                _txtReleaseYear.Text = SelectedMovie.ReleaseYear.ToString();
            };
        }
        private void OnSave ( object sender, EventArgs e )
        {
            //TODO: Add validation
            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;

            movie.IsClassic = _chkIsClassic.Checked;
            movie.RunLength = GetInt32(_txtRunLength);
            movie.ReleaseYear = GetInt32(_txtReleaseYear);

            if (!movie.Validate(out var error))
            {
                DisplayError(error, "Save");
                return;
            };

            //Get rid of form by
            // setting Form's DialogResult to a reasonable value
            // Call Close()
            SelectedMovie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetInt32 ( TextBox control )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }
    }
}
