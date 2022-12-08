using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie //: IValidatableObject
    {

        public Movie () : this("", "")
        { 
        }

        public Movie ( string title ) : this(title, "")
        {
            Title = title;
        }

        public Movie ( string title, string description ) : base()
        {

            Title = title;
            Description = description;
        }

        /// <summary> Gets the unique ID. </summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the title.</summary>
        //[RequiredAttribute()] - takes longer but accurate
        //[Required()] - parens not required
        [Required(AllowEmptyStrings = false)]
        [StringLengthAttribute(100, MinimumLength = 1)]
        public string Title 
        {
            //Expression body
            //get { return _title ?? ""; }
            // set { _title = value?.Trim() ?? ""; }
            get => _title ?? "";
            set => _title = value?.Trim() ?? "";
        }
        private string _title;
        public string  Description
        {
            //get { return _description ?? ""; }
            //set { _description = value?.Trim() ?? ""; }
            get => _description ?? "";
            set => _description = value?.Trim() ?? "";
        }
        private string _description;

        [Range(0, Int32.MaxValue, ErrorMessage = "Run length must be >= 0.")]
        [Display(Name = "Run Length")]
        public int RunLength { get; set; }

        [Range(1900, 2100)]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; } = 1900;

        [Required(AllowEmptyStrings = false)]
        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value?.Trim() ?? ""; }
        }
        private string _rating;

        /// <summary> Determines if the movie is black and white.</summary>
        public bool IsClassic { get; set; }

        /// <summary> Determines if the movie is black and white. </summary>
        //public bool IsBlackAndWhite => ReleaseYear < YearColorWasIntroduced;
        //{
        //    //get { return ReleaseYear < YearColorWasIntroduced; }
        //    get => ReleaseYear < YearColorWasIntroduced;
        //}

        //public const int YearColorWasIntroduced = 1939;

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
            movie.Id = Id;
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;
        }

        public override string ToString () => Title;
        //{
        //    var str = base.ToString();
        //    return Title;
        //}

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    var errors = new List<ValidationResult>();

        //    //if (Title.Length == 0)
        //    //    errors.Add(new ValidationResult("Title is required", new[] { nameof(Title) }));

        //    //if (Rating.Length == 0)
        //    //    errors.Add(new ValidationResult("Rating is required", new[] { nameof(Rating) }));

        //    //if (RunLength <= 0)
        //    //    errors.Add(new ValidationResult("Run length must be > 0", new[] { nameof(RunLength) }));

        //    //if (ReleaseYear < 1900)
        //    //    errors.Add(new ValidationResult("Release year must be >= 1900", new[] { nameof(ReleaseYear) }));

        //    return errors;
        //}

        [Obsolete("Depreciated in v1. Use NewMethod instead.")]
        public void OldMethod ()
        { }

        [System.Diagnostics.Conditional("DEBUG")]
        public void Dump ()
        { }
    }
}