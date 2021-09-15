using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.BookModels
{
    public class BookDetail
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public bool BestSeller { get; set; }
        public DateTime DatePublished { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
