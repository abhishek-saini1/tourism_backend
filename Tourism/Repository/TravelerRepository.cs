using Tourism.Models;

namespace Tourism.Repository
{
    public class TravelerRepository:TravelerInterface
    {
        private readonly TourismDbContext _context;

        public TravelerRepository(TourismDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Traveler> getelements()
        {
            return _context.travelers.ToList();
        }


        public void postelements(Traveler traveler)
        {
            _context.travelers.Add(traveler);
            _context.SaveChanges();
        }


        public void delete(int id)
        {
            var a = _context.travelers.Find(id);
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

        public void update(int id, Traveler traveler)
        {
            var a = _context.travelers.Find(id);
            if (a != null)
            {
                a.Email = traveler.Email;
                a.Phone = traveler.Phone;
                a.FullName = traveler.FullName;
                a.Username = traveler.Username;
                a.Password = traveler.Password;
                
               

                _context.SaveChanges();

            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }

    }

}

