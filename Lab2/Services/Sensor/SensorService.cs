using Lab2.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Sensor
{
    public class SensorService
    {
        private const int numInputs = 12;
        public SensorService()
        {

        }

        // u0 – травоїдне на передньому плані;
        // u1 – хижак на передньому плані;
        // u2 – рослина на передньому плані;
        // u3 – травоїдне ліворуч;
        // u4 – хижак ліворуч;
        // u5 – рослина ліворуч;
        // u6 – травоїдне праворуч;
        // u7 – хижак праворуч;
        // u8 – рослина праворуч;
        // u9 – близькість травоїдного;
        // u10 – близькість хижака;
        // u11 – близькість рослини.
        public int[] GetInputsForNetwork(List<Agent> allAgents, Agent currentAgent, LocationService service)
        {
           
            int[] inputs = new int[numInputs];
            var proximity = service.getProximityPoints();
            var front = service.getFrontPoints();
            var left = service.getLeftPoints();
            var right = service.getRightPoints();

            foreach(var f in front)
            {
                var herbivirous = allAgents.Where(a => a.AgentLocation.X == f.X && a.AgentLocation.Y == f.Y && a.AgentType == AgentTypes.Herbivorous);
                inputs[0] = herbivirous.Count();

                var predators = allAgents.Where(a => a.AgentLocation.X == f.X && a.AgentLocation.Y == f.Y && a.AgentType == AgentTypes.Predator);
                inputs[1] = predators.Count();

                var plants = allAgents.Where(a => a.AgentLocation.X == f.X && a.AgentLocation.Y == f.Y && a.AgentType == AgentTypes.Plant);
                inputs[2] = plants.Count();
            }

            foreach (var l in left)
            {
                var herbivirous = allAgents.Where(a => a.AgentLocation.X == l.X && a.AgentLocation.Y == l.Y && a.AgentType == AgentTypes.Herbivorous);
                inputs[3] = herbivirous.Count();

                var predators = allAgents.Where(a => a.AgentLocation.X == l.X && a.AgentLocation.Y == l.Y && a.AgentType == AgentTypes.Predator);
                inputs[4] = predators.Count();

                var plants = allAgents.Where(a => a.AgentLocation.X == l.X && a.AgentLocation.Y == l.Y && a.AgentType == AgentTypes.Plant);
                inputs[5] = plants.Count();
            }

            foreach (var r in right)
            {
                var herbivirous = allAgents.Where(a => a.AgentLocation.X == r.X && a.AgentLocation.Y == r.Y && a.AgentType == AgentTypes.Herbivorous);
                inputs[6] = herbivirous.Count();

                var predators = allAgents.Where(a => a.AgentLocation.X == r.X && a.AgentLocation.Y == r.Y && a.AgentType == AgentTypes.Predator);
                inputs[7] = predators.Count();

                var plants = allAgents.Where(a => a.AgentLocation.X == r.X && a.AgentLocation.Y == r.Y && a.AgentType == AgentTypes.Plant);
                inputs[8] = plants.Count();
            }

            foreach(var p in proximity)
            {
                var herbivirous = allAgents.Where(a => a.AgentLocation.X == p.X && a.AgentLocation.Y == p.Y && a.AgentType == AgentTypes.Herbivorous);
                inputs[9] = herbivirous.Count();

                var predators = allAgents.Where(a => a.AgentLocation.X == p.X && a.AgentLocation.Y == p.Y && a.AgentType == AgentTypes.Predator);
                inputs[10] = predators.Count();

                var plants = allAgents.Where(a => a.AgentLocation.X == p.X && a.AgentLocation.Y == p.Y && a.AgentType == AgentTypes.Plant);
                inputs[11] = plants.Count();
            }

            return inputs;
        }

        // перевірити, чи в близькості є агент із харчового ланцюга, якого можна з'їсти
        public Agent getAgentToEat(List<Agent> allAgents, List<Point> ProximityPoints, Agent currentAgent)
        {
            List<Agent> agents = new List<Agent>();

            Agent agentToEat = null;

            foreach (var p in ProximityPoints)
            {
                var agent = allAgents.Where(a => a.AgentLocation.X == p.X && a.AgentLocation.Y == p.Y).ToList();
                agents.AddRange(agent);
            }

            if(currentAgent.AgentType == AgentTypes.Herbivorous)
            {
                var plantsToEat = agents.Where(a => a.AgentType == AgentTypes.Plant).ToList();
                if (plantsToEat.Count != 0)
                    agentToEat = plantsToEat.First();
            }

            if (currentAgent.AgentType == AgentTypes.Predator)
            {
                var herbivitousToEat = agents.Where(a => a.AgentType == AgentTypes.Herbivorous).ToList();
                if (herbivitousToEat.Count != 0)
                    agentToEat = herbivitousToEat.First();
            }
            return agentToEat;
        }
    }
}
