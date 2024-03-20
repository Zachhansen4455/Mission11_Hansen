using Microsoft.AspNetCore.Mvc;
using Mission11_Hansen.Models;
using Mission11_Hansen.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Hansen.Controllers
{
    // home controller
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        //dont name it page. name var pageNum
        // this is used for pagination. doing 5 records per page
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var blah = new ProjectListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(blah);
        }
    }
}
