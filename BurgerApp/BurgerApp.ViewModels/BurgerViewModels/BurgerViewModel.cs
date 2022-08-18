using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the burger name")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter the burger Price")]
        public double Price { get; set; }
        //public bool HasFries { get; set; }
        //public bool HasBBQSauce { get; set; }
        [Display(Name = "ImageUrl")]
        [Required(ErrorMessage = "Please enter the burger Image Url")]
        public string ImageUrl { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter the burger Description")]
        public string Description { get; set; }
    }
}
