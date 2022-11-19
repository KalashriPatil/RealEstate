namespace RealEstate.Model
{
    public class Properties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool isTrending { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
    }
}
