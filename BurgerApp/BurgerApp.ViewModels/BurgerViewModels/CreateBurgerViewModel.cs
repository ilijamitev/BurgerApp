using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.BurgerViewModels
{
    public class CreateBurgerViewModel
    {
        // KAJ REQUIRED DA SE STAVA NULLABLE ? SEKOGAS

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the burger name")]
        public string? Name { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter the burger price")]
        //[Range(1, double.MaxValue, ErrorMessage = "Please enter price greather than 1")]
        public double? Price { get; set; }
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter the burger description")]
        public string? Description { get; set; }
    }


}
