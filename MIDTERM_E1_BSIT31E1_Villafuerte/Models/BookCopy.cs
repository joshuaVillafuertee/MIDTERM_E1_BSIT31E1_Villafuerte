namespace MIDTERM_E1_BSIT31E1_Villafuerte.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public DateTime? PulloutDate { get; set; }
        public string? PulloutReason { get; set; }
    }
}
