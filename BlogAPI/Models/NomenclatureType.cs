using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class NomenclatureType
    {
        [Column("id")]
        public int Id { get; }
        [Column("title")]
        public string Title { get; set; }
    }
}
