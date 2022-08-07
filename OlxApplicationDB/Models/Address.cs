using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxApplicationDB.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        [MaxLength(20)]
        public string Town { get; set; }
        [MaxLength(20)]
        public string Street { get; set; }
        public int NumberStreet { get; set; }
    }
}
