using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Tourism.Models;

namespace Tourism.Repository
{
    public class AgentRepository : AgentInterface { 
      private readonly TourismDbContext _context;

    public AgentRepository(TourismDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Agent> getelements()
    {
        return _context.agents.ToList();
    }


    public void postelements(Agent agent)
    {
        _context.agents.Add(agent);
        _context.SaveChanges();
    }


    public void delete(int id)
    {
        var y = _context.agents.Find(id);
        if (y != null)
        {
            _context.Remove(y);
            _context.SaveChanges();
        }
        else
        {

            throw new NotImplementedException("not found");
        }
    }

    public void update(int id, Agent agent)
    {
        var a = _context.agents.Find(id);
        if (a != null)
        {
                a.Email=agent.Email;
                a.FullName=agent.FullName;
                a.IsApproved=agent.IsApproved;
                a.Password=agent.Password;
                a.Phone=agent.Phone;
                a.Username=agent.Username;
            _context.SaveChanges();

        }
        else
        {

            throw new NotImplementedException("not found");
            }
        }



        public async Task<Agent> GetAgentById(int id)
        {
            var agent = await _context.Set<Agent>().FirstOrDefaultAsync(d => d.Id == id);
            if (agent == null)
            {
                return null;
            }

            return agent;
        }

    }
    }

