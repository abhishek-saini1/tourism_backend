using System.Numerics;
using Tourism.Models;

namespace Tourism.Repository
{
    public interface AgentInterface
    {

        IEnumerable<Agent> getelements();
        void postelements(Agent agent);
        void delete(int id);
        void update(int id, Agent agent);
        Task<Agent> GetAgentById(int id);
    }
}
