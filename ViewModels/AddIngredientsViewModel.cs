using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WNWN.Models;

namespace WNWN.ViewModels
{
    public class AddIngredientsViewModel
    {
        [Required(ErrorMessage = " Ingredient name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters")]
        public string Name { get; set; }
        public int IngredientId { get; set; }
        public int FoodGroupId { get; set; }
        public int UnitId { get; set; }
        public double Weight { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<SelectListItem> Groups { get; set; }
        public List<SelectListItem> Units { get; set; }

        public AddIngredientsViewModel(List<FoodGroup> groups, List<Units> units)
        {
            Groups = new List<SelectListItem>();
            Units = new List<SelectListItem>();

            foreach (FoodGroup group in groups)
            {
                Groups.Add(new SelectListItem
                {
                    Value = group.Id.ToString(),
                    Text = group.Name
                });
            }

            foreach (Units unit in units)
            {
                Units.Add(new SelectListItem
                {
                    Value = unit.Id.ToString(),
                    Text = unit.Name
                });
            }

        }
        public AddIngredientsViewModel() {  }
    }
}