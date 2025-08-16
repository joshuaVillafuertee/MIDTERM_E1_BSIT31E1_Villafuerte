namespace MIDTERM_E1_BSIT31E1_Villafuerte.Models
{
    public class AddBookView
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Copies { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
