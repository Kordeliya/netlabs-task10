using DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTESTORMPROJECT.Entity
{
    [Table("Book")]
    public class Book
    {
        [Column("Id", true)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Author")]
        public string Author { get; set; }
    }
}