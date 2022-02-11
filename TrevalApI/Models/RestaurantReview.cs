using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrevalApI.Models
{
    [Table("RestaurantReviews")]
    public class RestaurantReview
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int Restaurant_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [ForeignKey("Restaurant_id")]
        public Restaurant Restaurant { get; set; }
    }
}
