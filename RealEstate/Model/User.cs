namespace RealEstate.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public ICollection<Properties>  properties { get; set; }  //one to many relation between user and property
    }
}
