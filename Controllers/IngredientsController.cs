using WNWN.ViewModels;
using WNWN.Data;
using WNWN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WNWN.Controllers
{
    public class IngredientsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Ingredients> ingredients = new List<Ingredients>(IngredientsData.GetAll());

            return View(ingredients);
        }

        public IActionResult Add()
        {
            AddIngredientsViewModel addIngredientsViewModel = new AddIngredientsViewModel();

            return View(addIngredientsViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddIngredientsViewModel addIngredientsViewModel)
        {
            if (ModelState.IsValid)
            {
                Ingredients newIngredients = new Ingredients
                {
                    Name = addIngredientsViewModel.Name,
                    Group = addIngredientsViewModel.Group,
                    ContactEmail = addIngredientsViewModel.ContactEmail,
                    Weight = addIngredientsViewModel.Weight,
                    ExpirationDate = addIngredientsViewModel.ExpirationDate
                };

                IngredientsData.Add(newIngredients);

                return Redirect("/Ingredients");
            }

            return View(addIngredientsViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = IngredientsData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] ingredientIds)
        {
            foreach (int ingredientId in ingredientIds)
            {
                IngredientsData.Remove(ingredientId);
            }

            return Redirect("/Ingredients");
        }
    }
}
