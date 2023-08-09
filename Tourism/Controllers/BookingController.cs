using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Models;
using Tourism.Repository;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingInterface _irepository;
        public BookingController(BookingInterface repository)
        {

            _irepository = repository;
        }




        [HttpGet]
        public ActionResult<IEnumerable<BookingTrip>> getbooking()
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
        public void post(BookingTrip bookingTrip)
        {
            try
            {
                _irepository.postelements(bookingTrip);
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
        public void updateby(int id, BookingTrip bookingTrip)
        {
            try
            {
                _irepository.update(id, bookingTrip);

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }



    }
}
