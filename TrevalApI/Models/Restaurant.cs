using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrevalApI.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Phone_number { get; set; }
        public string Restaurant_email { get; set; }
        public string Address { get; set; }
        public string Opens { get; set; }
        public string Closes { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Area { get; set; }
        public string Postal_code { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Price { get; set; }
        public string Reserve_url { get; set; }
        public string Mobile_reserve_url { get; set; }
        public string Image_url { get; set; }
        public List<RestaurantReview> Reviews { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
