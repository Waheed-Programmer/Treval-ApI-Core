using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrevalApI.Models;

namespace TrevalApI.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Option):base(Option)
        {

        }

        public DbSet<Hotel> hotels { get; set; }
        public DbSet<HotelReview> hotelReviews { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }

    }
}
