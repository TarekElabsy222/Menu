namespace Menu.Models
{
    public class DishIngredients
    {
        public int DishID { get; set; }
        public Dish Dish { get; set; }

        public int IngredientsID { get; set; }
        public Ingredients? Ingredients { get; set; }
    }
}
