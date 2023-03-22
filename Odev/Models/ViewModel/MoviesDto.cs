using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Odev.Models.ViewModel
{
    public class MoviesDto
    {
        public int MovieID { get; set; }

        
        public string MovieName { get; set; }

        
        public bool IsVision { get; set; }

        
        public string MovieDescription { get; set; }
        public string ImageFile { get; set; }

       
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
