using MVCTESTORMPROJECT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTESTORMPROJECT.Controllers
{
    public class LibraryController : Controller
    {
        MyContext context = new MyContext("MyConName");
        List<Book> _BookModel;
        public ActionResult Index()
        {
            _BookModel = context.Books.GetList().ToList();
            return View("Index", _BookModel);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            try
            {
                context.Books.CreateNew(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                Exception inner = e.InnerException;

                while (inner != null)
                {
                    ModelState.AddModelError(string.Empty, inner.Message);
                    inner = inner.InnerException;
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            context.Books.DeleteById(id);
            return Index();
        }


        public ActionResult EditBook(int id)
        {
            Book book = context.Books.GetById(id);
            return View("EditBook", book);
        }


        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            try
            {
                context.Books.Update(book);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                Exception inner = e.InnerException;

                while (inner != null)
                {
                    ModelState.AddModelError(string.Empty, inner.Message);
                    inner = inner.InnerException;
                }
            }
            return View();
        }



    }

}
