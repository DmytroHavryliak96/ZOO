using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Filter
{
    public class FilterService
    {
        public FilterService()
        {

        }

        public List<Agent> getMigratingAgents(List<Agent> agents)
        {
            List<Agent> migratingAgents = agents.Where(a => a.AgentType == AgentTypes.Herbivorous || a.AgentType == AgentTypes.Predator).ToList();
            return migratingAgents;
        }

        
    }
}
