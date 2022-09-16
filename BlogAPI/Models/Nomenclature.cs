using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class Nomenclature
    {
        [Column("id")]
        public int Id { get; }
        [Column("title")]
        public string Title { get; set; }
        [Column("pages")]
        public int Pages { get; set; }
        [Column("authorid")]
        public int AuthorId { get; set; }
        [Column("typeid")]
        public int TypeId { get; set; }
    }
}
