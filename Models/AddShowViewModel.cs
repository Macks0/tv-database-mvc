namespace TV_Show_Database.Models
{
    public class AddShowViewModel
    {
        public string Title { get; set; } // Title of the show
        public string Genre { get; set; } // Genre of the show
        public int ReleaseYear { get; set; } // Year show came out
        public decimal Rating { get; set; } // How much did I like the show?
        public bool Recommend { get; set; }
    }
}
