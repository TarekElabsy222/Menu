using Menu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public IActionResult Index(string searchString)
        {
            var dish = from d in _context.Dishes
                       select d;

            if(!string.IsNullOrEmpty(searchString) )
            {
                dish = dish.Where(d => d.Name.Contains(searchString));
                return View(dish.ToList());
            }
            var result = _context.Dishes.ToList();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var dish = _context.Dishes
                .Include(d => d.DishIngredients)
                .ThenInclude(di => di.Ingredients)
                .FirstOrDefault(i=> i.Id == id);

            return View(dish);
        }
    }
}
