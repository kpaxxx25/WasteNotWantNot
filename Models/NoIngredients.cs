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
        [Key]
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string Name { get; set; }
        public int GroupsId { get; set; }
        public FoodGroup Groups { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Ingredients @ingredients &&
                Id == @ingredients.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
