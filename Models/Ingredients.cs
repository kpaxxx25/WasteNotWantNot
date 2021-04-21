using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WNWN.Models
{
    public class Ingredients
    {
        [MaxLength(450)]
        [Required]
        public string UserId { get; set; }
        public int Id { get; private set; }
        static private int nextId = 1;
        public Ingredients()
        {
            Id = nextId;
            nextId++;
        }
        public string Name { get; set; }
        public FoodGroup Group { get; set; }
        public double Weight { get; set; }
        public Units Unit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ExpectedDate;

        public Ingredients(string name, Units units, FoodGroup group, double weight, DateTime expirationDate)
        {
            Name = name;
            Unit = units;
            Group = group;
            Weight = weight;
            ExpirationDate = expirationDate;
        }

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
