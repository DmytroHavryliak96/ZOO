using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.World
{
    public interface ISimulation
    {
        void AddAllAgents(List<Agent> agents);
        void RunSimulation();
        void RunIteration();
      
    }
}
