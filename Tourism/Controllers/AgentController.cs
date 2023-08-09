using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Tourism.Models;
using Tourism.Repository;

namespace Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AgentInterface _irepository;
        public AgentController(AgentInterface repository)
        {

            _irepository = repository;
        }




        [HttpGet]
        public ActionResult<IEnumerable<Agent>> getagent()
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
        public void post(Agent agent)
        {
            try
            {
                _irepository.postelements(agent);
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
        public void updateby(int id, Agent agent)
        {
            try
            {
                _irepository.update(id, agent);

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgentId(int id)
        {
            try
            {
                var agent = await _irepository.GetAgentById(id);
                if (agent == null)
                    return NotFound();

                return Ok(agent);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("Error retrieving agent by ID: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the doctor.");
            }
        }


    }
}
