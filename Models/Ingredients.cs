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
        public int Id { get; private set; }
        static private int nextId = 1;
        public Ingredients()
        {
            Id = nextId;
            nextId++;
        }
        public string Name { get; set; }
        public FoodGroup Group { get; set; }
        public string ContactEmail { get; set; }
        public int Weight { get; set; }
        public int ExpirationDate { get; set; }
        public Ingredients(string name, FoodGroup group, string contactEmail, int weight, int expirationDate)
        {
            Name = name;
            Group = group;
            ContactEmail = contactEmail;
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
