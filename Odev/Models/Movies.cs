using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Odev.Models
{
    public class Movies
    {
        public int ID { get; set; }
        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        [DisplayName("Vision")]
        public bool IsVision { get; set; }
        [DisplayName("Movie Description")]
        public string? MovieDescription { get; set; } 
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public Category MovieCategory { get; set; }
        public int CategoryID { get; set; }
        public string? ImageFile { get; set; } = "/img/images.jpg";
    }
}
