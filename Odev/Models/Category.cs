using System.ComponentModel;

namespace Odev.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Category Description")]
        public string? CategoryDescription { get; set; }
        public List<Movies> CategoryMovies { get; set; }
        public Category()
        {
            CategoryMovies = new List<Movies>();
        }
    }
}
