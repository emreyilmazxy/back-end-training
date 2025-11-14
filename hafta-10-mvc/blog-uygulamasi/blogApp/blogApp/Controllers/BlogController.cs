using blogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogApp.Controllers
{
    public class BlogController : Controller
    {
        private static int _nextId = 1;
        private static List<BlogPost> _posts = new List<BlogPost>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.CurrentTime = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            if (ModelState.IsValid) 
            {
                blogPost.Id = _nextId++;
                _posts.Add(blogPost);

            TempData["SuccessMessage"] = "Blog postu başarıyla gönderildi";
                return RedirectToAction(nameof(Index));

            }   
            ViewBag.CurrentTime = DateTime.Now;
            return View(blogPost);
        }

        public IActionResult Details(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post is null)
            {
                return NotFound();
            }
            ViewData["CreatedAgo"] = $"{(DateTime.Now - post.CreatedAt).TotalMinutes} dakika önce";

            return View(post);
        }
    }
}
