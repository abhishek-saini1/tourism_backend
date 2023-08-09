using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Models;
using Tourism.Repository;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelerController : ControllerBase
    {
        private readonly TravelerInterface _irepository;
        public TravelerController(TravelerInterface repository)
        {

            _irepository = repository;
        }




        [HttpGet]
        public ActionResult<IEnumerable<Traveler>> gettraveler()
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
        public void post(Traveler traveler)
        {
            try
            {
                _irepository.postelements(traveler);
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
        public void updateby(int id, Traveler traveler)
        {
            try
            {
                _irepository.update(id, traveler);

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }



    }
}
