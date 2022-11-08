namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
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

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            do
            {
                //Showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_movies.Add(child.SelectedMovie, out var error) != null)
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Add Failed");
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            _movies.Remove(movie.Id);
            UpdateUI();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_movies.Update(movie.Id, child.SelectedMovie, out var error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Update Failed.");
            } while (true);

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

        private void UpdateUI()
        {
            UpdateUI(false);
        }
        private void UpdateUI ( bool initialLoad )
        {
            //Get movies
            var movies = _movies.GetAll();

            //Extension methods - static methods on static classes
            // 1. Expose a static method as an instance method for discoverability
            // 2. Called like instance methods (on an instance)
            // 3. Compiler rewrites code to call static method on static class
            //Enumerable.Count(movies) == movies.Count()
            if (initialLoad &&
                //movies.Count() == 0)
                //movies.FirstOrDefault() == null)
                !movies.Any())
            {
                if (Confirm("Do you want to seed some movies?", "Database Empty"))
                {
                    //SeedMovieDatabase.Seed(_movies);
                    _movies.Seed();
                    movies = _movies.GetAll();
                };

            };
 
            _lstMovies.Items.Clear();

            //How to treat functions as data
            //Func<Movie, string> someFunc = OrderByTitle;
            //var someResult = someFunc(new Movie());

            //Order movies by title, then by release year
            //var items = movies.OrderBy(OrderByTitle)
            //               .ThenBy(OrderByReleaseYear)
            var items = movies.OrderBy(x => x.Title)
                              .ThenBy(x => x.ReleaseYear)
                              .ToArray();
            //movies = movies.ThenBy();

            //Use Enumerable
            //_lstMovies.Items.AddRange(Enumerable.ToArray(movies));
            _lstMovies.Items.AddRange(items);
            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);

        }
        //private string OrderByTitle ( Movie movie )
        //{
        //    return movie.Title;
        //}

        //private int OrderByReleaseYear( Movie movie )
        //{
        //    return movie.ReleaseYear;
        //}
        private Movie GetSelectedMovie ()
        {

            //var allTextBoxes = Controls.OfType<Textbox>();
            //IEnumerable<Movie> temp = _lstMovies.SelectedItems.OfType<Movie>();

            return _lstMovies.SelectedItem as Movie;
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


       // private Movie _movie;
       // private MovieDatabase _movies = new MovieDatabase();
        private IMovieDatabase _movies = new Memory.MemoryMovieDatabase();
    }
}