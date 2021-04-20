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

        [StringLength(500, ErrorMessage = "Character length is too long!")]
        public FoodGroup Group { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public int Weight { get; set; }

        public int ExpirationDate { get; set; }

        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(FoodGroup.Fruit.ToString(), ((int)FoodGroup.Fruit).ToString()),
            new SelectListItem(FoodGroup.Vegetable.ToString(), ((int)FoodGroup.Vegetable).ToString()),
            new SelectListItem(FoodGroup.Grain.ToString(), ((int)FoodGroup.Grain).ToString()),
            new SelectListItem(FoodGroup.Protein.ToString(), ((int)FoodGroup.Protein).ToString()),
            new SelectListItem(FoodGroup.Dairy.ToString(), ((int)FoodGroup.Dairy).ToString()),
        };
    }
}
