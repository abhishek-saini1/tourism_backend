using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Tourism.Models
{
    public class TourismDbContext:DbContext
    {
        public TourismDbContext(DbContextOptions<TourismDbContext> Options) : base(Options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }



        public DbSet<Agent> agents { get; set; }
        public DbSet<Traveler> travelers { get; set; }

        public DbSet<Admin> admins { get; set; }

        public DbSet<BookingTrip> bookings { get; set; }

        public DbSet<Trips> trips { get; set; }
        public DbSet<FeedBack> feedbacks { get; set; }


        public DbSet<Gallery> gallery { get; set; }

    }
}
