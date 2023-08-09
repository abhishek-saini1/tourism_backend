using System.Numerics;
using Tourism.Models;

namespace Tourism.Repository
{
    public interface AdminInterface
    {    //admin
        IEnumerable<Admin> getelements();
        void postelements(Admin admin);
        void delete(int id);
        void update(int id, Admin admin);

        

    }
}
