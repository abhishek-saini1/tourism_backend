using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Models;
using Tourism.Repository;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminInterface _irepository;
        public AdminController(AdminInterface repository)
        {

            _irepository = repository;
        }




        [HttpGet]
        public ActionResult<IEnumerable<Admin>> getadmin()
        {
            try
            {
                var a = _irepository.getelements();
                return Ok(a);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public void post(Admin admin)
        {
            try
            {
                _irepository.postelements(admin);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }


        [HttpDelete]

        public void delete(int id)
        {
            try
            {
                _irepository.delete(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public void updateby(int id, Admin admin)
        {
            try
            {
                _irepository.update(id, admin);
                
            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }
        }



    }
}
