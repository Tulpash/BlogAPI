using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class Book
    {
        [Column("id")]
        public int Id { get; }
        [Column("title")]
        public string Title { get; set; }
        [Column("pages")]
        public int Pages { get; set; }
        [Column("authorid")]
        public string AuthorId { get; set; }
    }
}
