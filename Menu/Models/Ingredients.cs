namespace Menu.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DishIngredients>? DishIngredients { get; set; }

    }
}
