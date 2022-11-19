using System.ComponentModel.DataAnnotations;

namespace RealEstate.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter ImageURL value")]
        public string ImageUrl  { get; set; }
        public ICollection<Properties> properties { get; set; }
    }
}
