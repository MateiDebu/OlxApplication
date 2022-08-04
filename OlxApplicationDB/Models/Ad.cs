namespace OlxApplicationDB.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }

    }
}
