using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrevalApI.Models
{
    [Table("HotelReviews")]
    public class HotelReview
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int Hotel_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [ForeignKey("Hotel_id")]
        public Hotel Hotel { get; set; }
    }
}
