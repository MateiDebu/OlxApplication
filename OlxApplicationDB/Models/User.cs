using System.ComponentModel.DataAnnotations;

namespace OlxApplicationDB.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(15)]
        public string Name { get; set; }
        public ICollection<Ad> Announces { get; set; }
    }
}
