using ORM.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [Table("Book")]
    public class Book
    {
        [Column("Id", true)]
        public int Id { get; set; }

        [Column("Name")]
        public int Name { get; set; }

        [Column("Author")]
        public int Author { get; set; }
    }
}
