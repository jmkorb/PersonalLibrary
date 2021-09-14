using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.BookModels
{
    public class BookEdit
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public bool BestSeller { get; set; }
        public DateTime DatePublished { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
