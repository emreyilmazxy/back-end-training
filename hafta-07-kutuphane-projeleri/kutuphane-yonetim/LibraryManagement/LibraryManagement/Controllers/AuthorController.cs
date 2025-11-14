using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult List()
        {
            var authorList = MockData.authors.Select(b => new AuthorListViewModel
            {
               
                Id = b.Id,
                FullName = $"{b.FirstName} {b.LastName}"

            }).ToList();
            return View(authorList);  
        }

        public IActionResult Details(int id)
        {
            var author = MockData.authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
                return NotFound();

            var books = MockData.books
                .Where(b => b.AuthorId == id)
                .Select(b => new BookSummaryViewModel
                {
                    Title = b.Title,
                    PublishDate = b.PublishDate
                }).ToList();

            var viewModel = new AuthorDetailViewModel
            {
                FullName = $"{author.FirstName} {author.LastName}",
                DateOfBirth = author.DateOfBirth,
                Books = books
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AuthorFormViewModel());
        }
        [HttpPost]
        public IActionResult Create(AuthorFormViewModel model)
        {
            if (!ModelState.IsValid) 
            {
            return View(model);

            }

            var author = new Author
            {
                Id = MockData.authors.Count + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            };

            MockData.authors.Add(author);



            return RedirectToAction("List");
        }
        [ HttpGet] 
        public IActionResult Delete(int id)
        {
            var author =MockData.authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
                return NotFound();
           
            return View(author);
        }
        [HttpPost]
        public IActionResult Delete(Author model)
        {
            var author = MockData.authors.FirstOrDefault(a => a.Id == model.Id);
            if (author == null)
                return NotFound();

            MockData.authors.Remove(author);
            return RedirectToAction("List");
        }
        [HttpGet]
        
        public IActionResult Edit(int id)
        {
            var author = MockData.authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
                return NotFound();

            var model = new AuthorFormViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            return View(model); 
        }
        [HttpPost]
        public IActionResult Edit(AuthorFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            var author = MockData.authors.FirstOrDefault(a => a.Id == model.Id);
            if (author == null)
            {
                return NotFound();
            }

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.DateOfBirth = model.DateOfBirth;



            return RedirectToAction("List");
        }
    }
}
