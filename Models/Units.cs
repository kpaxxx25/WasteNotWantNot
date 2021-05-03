namespace WNWN.Models
{
    public class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Units(string name)
        {
            Name = name;
        }
    }
}

