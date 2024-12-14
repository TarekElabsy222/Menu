namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public ICollection<DishIngredients> DishIngredients { get; set; }
    }
}
