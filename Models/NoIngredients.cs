using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WNWN.Models;

namespace WNWN.Models
{
    public class NoIngredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FoodList> OptionList { get; set; } 

        public NoIngredients(string name)
        {
            Name = name;
        }
        public NoIngredients()
        {
        }
    }
}

