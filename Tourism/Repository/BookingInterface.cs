using Tourism.Models;

namespace Tourism.Repository
{
    public interface BookingInterface
    {

        IEnumerable<BookingTrip> getelements();
        void postelements(BookingTrip bookingTrip);
        void delete(int id);
        void update(int id, BookingTrip bookingTrip);
    }
}
