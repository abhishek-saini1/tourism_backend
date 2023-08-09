using Tourism.Models;

namespace Tourism.Repository
{
    public class BookingRepository:BookingInterface
    {
        private readonly TourismDbContext _context;

        public BookingRepository(TourismDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BookingTrip> getelements()
        {
            return _context.bookings.ToList();
        }


        public void postelements(BookingTrip bookingTrip)
        {
            _context.bookings.Add(bookingTrip);
            _context.SaveChanges();
        }


        public void delete(int id)
        {
            var a = _context.bookings.Find(id);
            if (a != null)
            {
                _context.Remove(a);
                _context.SaveChanges();
            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }

        public void update(int id, BookingTrip bookingTrip)
        {
            var a = _context.bookings.Find(id);
            if (a != null)
            {
              a.TravelerName = bookingTrip.TravelerName;
                a.ReturnDate = bookingTrip.ReturnDate;
                a.Description = bookingTrip.Description;
                a.Accommodation= bookingTrip.Accommodation;
                a.NumberOfTravelers = bookingTrip.NumberOfTravelers;
                a.DepartureDate = bookingTrip.DepartureDate;
                a.Destination= bookingTrip.Destination;
                
                _context.SaveChanges();

            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }

    }
}
