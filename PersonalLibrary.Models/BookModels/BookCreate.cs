using PersonalLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.BookModels
{
    public class BookCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime DatePublished { get; set; }
        [Required]
        public  Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
