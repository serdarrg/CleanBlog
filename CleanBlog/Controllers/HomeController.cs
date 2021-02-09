using CleanBlog.Data;
using CleanBlog.Entity;
using CleanBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CleanBlog.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly HomeContext _context;

        public HomeController(HomeContext context)
        {
            _context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {

            var allBlogPosts = _context.BlogPosts.ToList();

            var viewModel = new HomeBlogListView { Blogs = allBlogPosts };

            return View(viewModel); 
        }

        [Route("/post/{blogPostId}")]
        public IActionResult Detail(int blogPostId)
        {

            var findBlog = _context.BlogPosts.Find(blogPostId);
            var viewModel = new HomeBlogDetailsView { Title = findBlog.Title, Content = findBlog.Content, Author = findBlog.Author.FullName, CreationDate = findBlog.CreationDate };

            return View(viewModel);
        }


        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/samplepost")]
        public IActionResult SamplePost()
        {
            return View();
        }
        
        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }


        [Route("/contact")]
        [HttpPost]
        public IActionResult Contact(Contact contacts,ContactViewModel viewModel)
        {
                if (!ModelState.IsValid)
                    return View(viewModel);

                _context.Contacts.Add(contacts);
                _context.SaveChanges();
                ModelState.Clear();
                return View();
        }

    }
}
