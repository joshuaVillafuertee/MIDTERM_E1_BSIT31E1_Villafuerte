namespace MIDTERM_E1_BSIT31E1_Villafuerte.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Biography { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
    }
}
