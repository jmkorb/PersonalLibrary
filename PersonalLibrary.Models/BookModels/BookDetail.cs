using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.BookModels
{
    public class BookDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public bool BestSeller { get; set; }
        [Required]
        public DateTime DatePublished { get; set; }
        [ForeignKey]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
