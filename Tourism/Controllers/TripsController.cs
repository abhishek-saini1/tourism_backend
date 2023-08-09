using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Models;
using Tourism.Repository;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly TripsInterface _irepository;
        public TripsController(TripsInterface repository)
        {

            _irepository = repository;
        }




        [HttpGet]
        public ActionResult<IEnumerable<Trips>> gettrips()
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
        public void post(Trips trips)
        {
            try
            {
                _irepository.postelements(trips);
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
        public void updateby(int id, Trips trips)
        {
            try
            {
                _irepository.update(id, trips);

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }



    }
}
