using WNWN.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;

namespace WNWN.ViewModels
{
    public class AddIngredientsViewModel
    {
        [Required(ErrorMessage = " Ingredient name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters")]
        public string Name { get; set; }

        public FoodGroup Group { get; set; }

        public double Weight { get; set; }

        public DateTime ExpirationDate { get; set; }

        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(FoodGroup.Fruit.ToString(), ((int)FoodGroup.Fruit).ToString()),
            new SelectListItem(FoodGroup.Vegetable.ToString(), ((int)FoodGroup.Vegetable).ToString()),
            new SelectListItem(FoodGroup.Grain.ToString(), ((int)FoodGroup.Grain).ToString()),
            new SelectListItem(FoodGroup.Protein.ToString(), ((int)FoodGroup.Protein).ToString()),
            new SelectListItem(FoodGroup.Dairy.ToString(), ((int)FoodGroup.Dairy).ToString()),
        };

        public Units Units { get; set; }

        public List<SelectListItem> Unit { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(Units.teaspoon.ToString(), ((int)Units.teaspoon).ToString()),
            new SelectListItem(Units.tablespoon.ToString(), ((int)Units.tablespoon).ToString()),
            new SelectListItem(Units.flOz.ToString(), ((int)Units.flOz).ToString()),
            new SelectListItem(Units.cup.ToString(), ((int)Units.cup).ToString()),
            new SelectListItem(Units.pint.ToString(), ((int)Units.pint).ToString()),
            new SelectListItem(Units.quart.ToString(), ((int)Units.quart).ToString()),
            new SelectListItem(Units.gallon.ToString(), ((int)Units.gallon).ToString()),
            new SelectListItem(Units.milliliter.ToString(), ((int)Units.milliliter).ToString()),
            new SelectListItem(Units.liter.ToString(), ((int)Units.liter).ToString()),
            new SelectListItem(Units.deciliter.ToString(), ((int)Units.deciliter).ToString()),
            new SelectListItem(Units.pound.ToString(), ((int)Units.pound).ToString()),
            new SelectListItem(Units.ounce.ToString(), ((int)Units.ounce).ToString()),
            new SelectListItem(Units.milligram.ToString(), ((int)Units.milligram).ToString()),
            new SelectListItem(Units.gram.ToString(), ((int)Units.gram).ToString()),
            new SelectListItem(Units.kilogram.ToString(), ((int)Units.kilogram).ToString()),
        };
    }
}