using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Data
{
    public class Genre
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public string GenreType { get; set; }

        public virtual List<Book> ListOfBooks { get; set; } = new List<Book>();

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
