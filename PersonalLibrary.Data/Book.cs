﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Data
{
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }

        public bool BestSeller { get; set; }

        public DateTime DatePublished { get; set; }
        [ForeignKey]
        public int AuthorId { get; set; }
        [Required]
        public virtual Author Author { get; set; }
        [ForeignKey]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual List<Genre> Genres { get; set; } = new List<Genre>();

    }
}
