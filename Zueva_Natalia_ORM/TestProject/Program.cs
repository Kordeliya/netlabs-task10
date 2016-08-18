using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MyContext context = new MyContext("MyConName");

           // context.Books.CreateNew(new Book{Name = "Идиот", Author="Достоевский"});

            var book = context.Books.GetById(1);

            Console.ReadKey();
        }
    }
}
