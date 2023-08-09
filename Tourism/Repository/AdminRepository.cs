using Microsoft.AspNetCore.Mvc;
using Tourism.Models;

namespace Tourism.Repository
{
    public class AdminRepository:AdminInterface
    {
        private readonly TourismDbContext _context;

        public AdminRepository(TourismDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Admin> getelements() 
        {
           return _context.admins.ToList();
        }


        public void postelements(Admin admin)
        {
            _context.admins.Add(admin);
            _context.SaveChanges();
        }


        public void delete(int  id)
        {
            var admin = _context.admins.Find(id);
            if (admin != null)
            {
                _context.Remove(admin);
                _context.SaveChanges();
            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }

        public void update(int id,Admin admin)
        {
            var a=_context.admins.Find(id);
            if(a != null)
            {
                a.AUserName = admin.AUserName;
                a.APassword = admin.APassword;
                a.AEmail = admin.AEmail;
                _context.SaveChanges();
               
            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }

    }
}
