using Lab2.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.BaseNetwork;

namespace Lab2.Agents
{
    public class Plant : Agent
    {
        public Plant(Point currentLocation) : base(currentLocation)
        {
            AgentType = AgentTypes.Plant;
            Direction = SightDirection.None;
        }

        public override void Eat()
        {
            throw new NotImplementedException("the plant mustn't eat");
        }

        public override int GetEnergyLevel()
        {
            throw new NotImplementedException("the plant have no energy level");
        }

        public override int GetGeneration()
        {
            throw new NotImplementedException("the plant has not generation field");
        }

        public override NeuralNetwork GetNetwork()
        {
            throw new NotImplementedException("the plant doesn't have brain");
        }

        public override void IncreseAge()
        {
            throw new NotImplementedException("the plant doesn't have age");
        }

        public override bool IsAlive()
        {
            throw new NotImplementedException("the plant doesn't have an energy");
        }

        public override void MoveAgent(Point destination)
        {
            throw new NotImplementedException("the plant cannot move");
        }

        public override void ReduceEnergy()
        {
            throw new NotImplementedException("the plant doesn't have energy");
        }

        public override void Reproduction()
        {
            throw new NotImplementedException("the plant doesn't reproduce itself");
        }

        public override int GetAge()
        {
            throw new NotImplementedException("the plant doesn't have age");
        }
    }
}
