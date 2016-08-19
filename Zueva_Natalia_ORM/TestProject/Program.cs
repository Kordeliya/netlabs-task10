using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            MyContext context = new MyContext("MyConName");

            context.Books.CreateNew(new Book{Name = "Большие надежды", Author="Чарльз Диккенс"});
            context.Books.CreateNew(new Book { Name = "Стихи", Author = "Владимир Маяковский" });
            context.Books.CreateNew(new Book { Name = "Посмотри на меня", Author = "Сесилия Ахерн" });

            var list = context.Books.GetList();

            var book = context.Books.GetById(1);
            context.Books.DeleteById(3);
            var book2 = context.Books.GetById(3);
           // context.Books.Update(new Book{ Id=2, Name = "Большие надежды222", Author="Чарльз Диккенс"});

            Console.ReadKey();
        }
    }
}
