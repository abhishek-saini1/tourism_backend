using Tourism.Models;

namespace Tourism.Repository
{
    public class TripRepository:TripsInterface
    {
        private readonly TourismDbContext _context;

        public TripRepository(TourismDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Trips> getelements()
        {
            return _context.trips.ToList();
        }


        public void postelements(Trips trips)
        {
            _context.trips.Add(trips);
            _context.SaveChanges();
        }


        public void delete(int id)
        {
            var a = _context.trips.Find(id);
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

        public void update(int id, Trips trips)
        {
            var a = _context.trips.Find(id);
            if (a != null)
            {
                a.Itinerary=trips.Itinerary;
                a.RatesPerHour=trips.RatesPerHour;
                a.RatesPerDay=trips.RatesPerDay;
                a.RatesPerTourPack=trips.RatesPerTourPack;
                a.Destination=trips.Destination;    
                a.TDetails=trips.TDetails;
                a.FoodAndAccommodation=trips.FoodAndAccommodation;
              
                _context.SaveChanges();

            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }

    }
}
