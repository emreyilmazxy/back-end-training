 using Microsoft.AspNetCore.Mvc;
using tekrarkütüphane.Models;

namespace tekrarkütüphane.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Extra(int? authorId)
        {
            var authors = MockData.authors.Select(x => new ExtraViewModel
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            }).ToList();

            var books = authorId == null ? MockData.books : MockData.books.Where(b => b.AuthorId == authorId).ToList();

            var model = new ExtraPageViewModel
            {
                SelectedAuthorId = authorId,
                Authors = authors,
                Books = books
            };

            return View(model);
        }

    }
}
