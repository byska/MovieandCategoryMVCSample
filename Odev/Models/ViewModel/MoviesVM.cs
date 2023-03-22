using Microsoft.AspNetCore.Mvc.Rendering;

namespace Odev.Models.ViewModel
{
    public class MoviesVM
    {
        public List<MoviesDto> movieList { get; set; }
        public Movies Movies { get; set; }
        public MoviesVM()
        {
            movieList=new List<MoviesDto>();
        }
        public List<SelectListItem> CategoriesForDropDown { get; set; }
    }
}
