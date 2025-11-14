using Microsoft.AspNetCore.Mvc;
using tekrarkütüphane.Models;

namespace tekrarkütüphane.Controllers
{
    public class BookController : Controller
    {
        Random random = new Random();
        public IActionResult List()
        {

            var books = MockData.books.Select( b=> new BookListViewModel
            {
                  Genre = b.Genre,
                    Id = b.Id,
                     Title = b.Title
            }).ToList();
            return View(books);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = MockData.books.FirstOrDefault(b => b.Id == id);
             
            if (book == null)
            {
                return NotFound();
            }

            var model = new BookFormViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                
            }

            var book = MockData.books.FirstOrDefault(b => b.Id == model.Id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = model.Title;
            book.Genre=model.Genre;
            book.Id = model.Id; 


            return RedirectToAction("List");
        }
        [HttpGet]         
        
        public IActionResult Delete(int id)
        {
            var book = MockData.books.FirstOrDefault(b => b.Id == id);
            if( book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [ HttpPost]    
        public IActionResult Delete(Book model)
        {
           var book = MockData.books.FirstOrDefault(b => b.Id == model.Id);
            if (book == null)
            {
                return NotFound();
            }
            MockData.books.Remove(book);
            return RedirectToAction("List");
        }

        public IActionResult Create() 
        {
        
        return View(new BookFormViewModel());
        }
        [HttpPost]
        public IActionResult Create(BookFormViewModel model)
        {

            int newId = MockData.books.Any()
              ? MockData.books.Max(b => b.Id) + 1
                   : 1;
            var book = new Book
            {
                Id = newId,
                AuthorId = random.Next(100),
                CopiesAvailable = random.Next(50),
                Genre = model.Genre,
                ISBN = random.Next(1000),
                PublishDate=DateTime.Now,
                 Title=model.Title
            };
            MockData.books.Add(book);

            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            var book = MockData.books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            var author = MockData.authors.FirstOrDefault(a => a.Id == book.AuthorId);

            var model = new BookDetailsViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                Author = author,
                CopiesAvailable = book.CopiesAvailable
            };

            return View(model);
        }
    }
}
