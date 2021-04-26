using WNWN.ViewModels;
using WNWN.Data;
using WNWN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WNWN.Controllers
{
    [Authorize]
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IngredientsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Ingredients> ingredients = new List<Ingredients>(_context.Ingredients.Where(x => x.User.UserName == User.Identity.Name).ToList());

            return View(ingredients);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddIngredientsViewModel addIngredientsViewModel = new AddIngredientsViewModel(_context.Groups.ToList(), _context.Units.ToList());

            return View(addIngredientsViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddIngredientsViewModel addIngredientsViewModel)
        {
            if (ModelState.IsValid)
            {
                var group = _context.Groups.Find(addIngredientsViewModel.FoodGroupId);
                var unit = _context.Units.Find(addIngredientsViewModel.UnitId);

                Ingredients newIngredients = new Ingredients
                {
                    User = _userManager.GetUserAsync(User).Result,
                    Name = addIngredientsViewModel.Name,
                    Groups = group,
                    Weight = addIngredientsViewModel.Weight,
                    ExpirationDate = addIngredientsViewModel.ExpirationDate,
                    Units = unit
                };

                _context.Ingredients.Add(newIngredients);
                _context.SaveChanges();

                return Redirect("/Ingredients");
            }

            return View(addIngredientsViewModel);
        }

        public IActionResult Delete()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var userId = _userManager.GetUserIdAsync(user).Result;
            List<Ingredients> ingredients = new List<Ingredients>(_context.Ingredients.Where(x => x.User.Id == userId).ToList());

            return View(ingredients);
        }

        [HttpPost]
        public IActionResult Delete(int[] ingredientIds)
        {
            foreach (int ingredientId in ingredientIds)
            {
                var ingredient = _context.Ingredients.Find(ingredientId);
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }

            return Redirect("/Ingredients");
        }
    }
}
