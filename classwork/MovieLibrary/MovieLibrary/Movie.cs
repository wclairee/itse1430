﻿namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        public int Id { get; private set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title 
        {

            get { return String.IsNullOrEmpty(_title) ? "" : _title; }
            set { _title = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }
        private string _title;

        //public string GetTitle ()
        //{
        //    return _title;
        //}
        //public void SetTitle ( string title )
        //{
        //    //this._title = title;
        //    _title = title;
        //}

        //TODO: Hide this...
        public string  Description
        { 
            get { return String.IsNullOrEmpty(_description) ? "" : _description; } 
            set { _description = String.IsNullOrEmpty(value) ? "" : value.Trim(); } 
        }
        private string _description;

        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength = 0; //in minutes
        //this is the same as below- auto property
        public int RunLength { get; set; }

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        public int ReleaseYear { get; set; } = 1900;

        public string Rating
        {
            get { return String.IsNullOrEmpty(_rating) ? "" : _rating; }
            set { _rating = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }
        private string _rating;

        public bool IsClassic { get; set; }

        //public bool IsBlackAndWhite () { return _releaseYear < 1939; }

        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1939; }
            //set { }
        }

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Clone ()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;
        }

        /// <summary>Copy the movie to another instance.</summary>
        /// <param name="movie">Movie to copy into.</param>
        public void CopyTo ( Movie movie )
        {
            //var areEqual = title == this.title;

            movie.Title = Title;
            movie.Description = Description; //this.description
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }

    }
}