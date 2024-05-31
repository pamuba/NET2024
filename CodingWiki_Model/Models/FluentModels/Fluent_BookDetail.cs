﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Fluent_BookDetail
    {
        //[Key]
        public int BookDetail_Id { get; set; }
        //[Required]
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public string Weight { get; set; }
        public string PriceRange { get; set; }

        //[ForeignKey("Book")]
        //public int Book_Id { get; set; }
        public Fluent_Book Fluent_Book { get; set; }
    }
}
