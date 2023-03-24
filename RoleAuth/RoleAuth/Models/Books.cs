using System.ComponentModel.DataAnnotations;

namespace RoleAuth.Models
{
    public class Books
    {

        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
