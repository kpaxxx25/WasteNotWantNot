namespace WNWN.Models
{
    public class FoodGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public FoodGroup(string name)
        {
            Name = name;
        }
    }
}
