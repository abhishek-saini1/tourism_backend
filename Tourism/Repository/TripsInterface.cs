using Tourism.Models;

namespace Tourism.Repository
{
    public interface TripsInterface
    {
        IEnumerable<Trips> getelements();
        void postelements(Trips trips);
        void delete(int id);
        void update(int id, Trips trips);
    }
}
