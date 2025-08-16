namespace MIDTERM_E1_BSIT31E1_Villafuerte.Models
{
    public class BookListView
    {
        public int Id { get; set; }  
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Copies { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsArchived { get; set; }
    }
}
