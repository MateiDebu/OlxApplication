namespace OlxApplicationDB.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ad> Announces { get; set; }
    }
}
