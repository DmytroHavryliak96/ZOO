using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Areas;
using Lab2.BaseNetwork;

namespace Lab2.Agents
{
    public class Herbivorous : MigratingAgent
    {
        public Herbivorous(Point currentLocation, int generation, NeuralNetwork network) 
            : base(currentLocation, generation, network)
        {
            AgentType = AgentTypes.Herbivorous;
            IsPredator = false;
            Metabolism = 4;
            EatingEnergy = 15;
        }
    }
}
