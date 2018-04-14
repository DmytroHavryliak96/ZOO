using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;
using Lab2.BaseNetwork;

namespace Lab2.Agents
{
    public class Predator : MigratingAgent
    {
        public Predator(Point currentLocation, int generation, NeuralNetwork network) 
            : base(currentLocation, generation, network)
        {
            AgentType = AgentTypes.Predator;
          
            IsPredator = true;
            Metabolism = 2;
            EatingEnergy = 30;
            
        }
    }
}
