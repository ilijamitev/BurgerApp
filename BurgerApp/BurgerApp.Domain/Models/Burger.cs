namespace BurgerApp.Domain.Models
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool HasFries { get; set; }
        public bool HasBBQSauce { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set; }

    }
}
