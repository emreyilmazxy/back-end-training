using Microsoft.AspNetCore.Mvc;
using tekrarkütüphane.Models;

namespace tekrarkütüphane.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult List()
        {
            var authors = MockData.authors.Select( a=> new AuthorListViewModel
            { 
              FullName= $"{a.FirstName} {a.LastName}",
              Id = a.Id
            }).ToList();
            return View(authors);
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
                return View(model);

            var author = MockData.authors.FirstOrDefault(b => b.Id == model.Id);
            if (author == null)
                return NotFound();

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.DateOfBirth = model.DateOfBirth;

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = MockData.authors.FirstOrDefault(a=> a.Id== id);
            if (author == null) 
            {
                return NotFound();
            }


            return View(author);

        }
        [HttpPost]
        public IActionResult Delete(Author model)
        {
           
            var author = MockData.authors.FirstOrDefault(a => a.Id == model.Id);
            if (author == null)
            {
                return NotFound();
            }
            MockData.authors.Remove(author);
            return RedirectToAction("List");

        }
        [HttpGet]
        public IActionResult Create()
        {
            var author = new AuthorFormViewModel();
            return View(author);
        }
        [HttpPost]
        public IActionResult Create(AuthorFormViewModel model)
        {
            var author = new Author
            {
                Id = MockData.authors.Any() ? MockData.authors.Max(a => a.Id) + 1 : 1,
                 DateOfBirth=model.DateOfBirth,
                  FirstName=model.FirstName,
                  LastName=model.LastName,
            }; 
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            MockData.authors.Add(author);
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            var author = MockData.authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
                return NotFound();
            var model = new AuthorDetailsViewModel
            { 
             DateOfBirth=author.DateOfBirth,
             FirstName=author.FirstName,
             LastName=author.LastName,
               Books= MockData.books.Where(b=>b.AuthorId == author.Id).ToList(),
            };    
            return View(model);
        }
       
    }
}
