using LibrararyService.Web.Models;
using LibrarryServiceReference;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibrararyService.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SearchType serchType, string searchString)
        {
            try
            {
            LibraryWebServiceSoapClient client = new LibraryWebServiceSoapClient(LibraryWebServiceSoapClient.EndpointConfiguration.LibraryWebServiceSoap12);

            if (!string.IsNullOrEmpty(searchString))
            {
                switch (serchType)
                {
                    case SearchType.Autor:
                        return View(new BookCategoryViewModel { Books = client.GetBooksByAuthor(searchString) });

                    case SearchType.Title:
                        return View(new BookCategoryViewModel{ Books = client.GetBooksByTitle(searchString)});

                    case SearchType.Category:
                        return View(new BookCategoryViewModel { Books = client.GetBooksByCategory(searchString) });

                }
            }
            }
            catch (Exception ex)
            {
                _logger.LogError("Err 1");
            }

            return View(new BookCategoryViewModel { Books = new Book[] { } });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}