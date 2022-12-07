using LibrarryServiceReference;

namespace LibrararyService.Web.Models
{
    public class BookCategoryViewModel
    {
        public Book[] Books { get; set; }

        public SearchType serchType { get; set; }

        public string SearchString { get; set; }
    }
}
