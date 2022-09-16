using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class Author
    {
        [Column("id")]
        public int Id { get; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("age")]
        public int Age { get; set; }
    }
}
