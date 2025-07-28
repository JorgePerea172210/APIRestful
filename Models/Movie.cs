using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRestful.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Last { get; set; }
        public string ImageURL { get; set; }
        public int Classification { get; set; }
        public DateTime CreatedAt { get; set; }
        //Relation with Category table
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public Movie()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
