using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;


namespace WNWN.Models
{
    public class Ingredients
    {   [Key]
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string Name { get; set; }
        public int FoodGroupId { get; set; }
        public FoodGroup Groups { get; set; }
        public double Weight { get; set; }
        public int UnitId { get; set; }
        public Units Units { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ExpectedDate;

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
