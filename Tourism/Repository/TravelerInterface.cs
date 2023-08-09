using Tourism.Models;

namespace Tourism.Repository
{
    public interface TravelerInterface
    {
        IEnumerable<Traveler> getelements();
        void postelements(Traveler traveler);
        void delete(int id);
        void update(int id, Traveler traveler);
    }
}
