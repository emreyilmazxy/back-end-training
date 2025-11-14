using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        public static string GenerateRandomIsbn()
        {
            Random random = new Random();
            return "978" + random.Next(100000000, 999999999).ToString();
        }


        public IActionResult List()
        {
            var booklist = MockData.books.Select(book => new BookListViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
            }).ToList();

            return View(booklist);
        }


        public IActionResult Details(int id)
        {

            var bookDetails = MockData.books.FirstOrDefault(b => b.Id == id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            var author = MockData.authors.FirstOrDefault(a => a.Id == bookDetails.AuthorId);
            var viewModel = new BookDetailViewModel()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Genre = bookDetails.Genre,
                PublishDate = bookDetails.PublishDate,
                CopiesAvailable = bookDetails.CopiesAvailable,
                AuthorFullName = author != null ? $"{author.FirstName} {author.LastName}" : "Bilinmiyor",
                AuthorBirthDate = author?.DateOfBirth ?? DateTime.MinValue

            };
            return View(viewModel);

        }
          
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = MockData.authors
       .Select(a => new { Id = a.Id, Name = a.FirstName + " " + a.LastName })
       .ToList();
            var viewModel = new BookFormViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = MockData.authors
             .Select(a => new { Id = a.Id, Name = a.FirstName + " " + a.LastName })
             .ToList();

                return View(model);
            }
           
            int newId = MockData.books.Any() ? MockData.books.Max(b => b.Id) + 1 : 1;

            var newBook = new Book
            { 
                   Id = newId,
                   AuthorId = model.AuthorId,
                   CopiesAvailable=1, 
                   Genre =model.Genre,
                   Title=model.Title,
                   Isbn = GenerateRandomIsbn(),
                   PublishDate = DateTime.Now
            };

            MockData.books.Add(newBook);

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = MockData.books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return View(book); 
        }
        [HttpPost]
        public IActionResult Delete(Book model)
        {

            var book= MockData.books.FirstOrDefault(b=> b.Id== model.Id);
            
            if(book== null)
                return NotFound();
            MockData.books.Remove(book);    
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = MockData.books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            ViewBag.Authors = MockData.authors
                .Select(a => new { Id = a.Id, Name = a.FirstName + " " + a.LastName })
                .ToList();

            var viewModel = new BookFormViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                AuthorId = book.AuthorId
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = MockData.authors
                    .Select(a => new { Id = a.Id, Name = a.FirstName + " " + a.LastName })
                    .ToList();

                return View(model);
            }

            var book = MockData.books.FirstOrDefault(b => b.Id == model.Id);
            if (book == null)
                return NotFound();

            book.Title = model.Title;
            book.Genre = model.Genre;
            book.AuthorId = model.AuthorId;

            return RedirectToAction("List");
        }

    }
}
