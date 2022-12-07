using System.ComponentModel.DataAnnotations;

namespace LibrararyService.Web.Models
{
    public enum SearchType
    {

        [Display(Name = "Автор")]
        Autor,
        Title,        
        Category

    }
}
