using PersonalLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.GenreModels
{
    public class GenreDetail
    {
        public int Id { get; set; }
        public string GenreType { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public virtual List<Book> ListOfBooks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
