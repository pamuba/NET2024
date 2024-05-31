using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Fluent_BookAuthorMap
    {
        [ForeignKey("Fluent_Book")]
        //[Key]
        public int Book_Id { get; set; }

        [ForeignKey("Fluent_Author")]
        //[Key]
        public int Author_Id { get; set; }

        public Fluent_Book Fluent_Book { get; set; }
        public Fluent_Author Fluent_Author { get; set; }
    }
}
