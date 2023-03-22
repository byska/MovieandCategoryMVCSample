namespace Odev.Models.ViewModel
{
    public class CategoriesVM
    {
        public List<CategoriesDto> categoryList { get; set; }
        public Category Categories { get; set; }
        public CategoriesVM()
        {
            categoryList= new List<CategoriesDto>();
        }
    }
}
