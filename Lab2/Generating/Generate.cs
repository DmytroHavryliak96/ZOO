using Lab2.Agents;
using Lab2.Areas;
using Lab2.BaseNetwork;
using Lab2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Generating
{
    public class Generate
    {
        // співвідношення агентів у системі
        private int amountOfAllAgents;
        private int amountOfPlants;
        private int amountOfHerbivorous;
        private int amountOfPredators;
        public int worldSize;
        List<Point> AllPoints;
        Random rand;

        public List<Agent> generatedAgents;

        public Generate(int WorldSize)
        {
            worldSize = WorldSize;
            AllPoints = new List<Point>();

            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    AllPoints.Add(new Point(i, j));
                }
            }


            amountOfAllAgents = (int)((worldSize * worldSize) * 0.75);
            amountOfPlants = amountOfAllAgents / 2;
            amountOfHerbivorous = amountOfPredators = (amountOfPlants / 2);
            rand = new Random();
        }

        public Agent GenerateNewPlant(List<Agent> allAgents)
        {
            AllPoints = new List<Point>();
            
            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    AllPoints.Add(new Point(i, j));
                }
            }

            for (int i = 0; i < allAgents.Count; i++)
                AllPoints.RemoveAll(p => allAgents[i].AgentLocation.X == p.X && allAgents[i].AgentLocation.Y == p.Y);

            int index = rand.Next(0, AllPoints.Count - 1);
            var agent = new Plant(new Point(AllPoints[index].X, AllPoints[index].Y));
            return agent;
        }

        public Agent GenerateNewMigratingAgent(List<Agent> allAgents, Agent currentAgent)
        {
            Agent agent = null;
            AllPoints = new List<Point>();

            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    AllPoints.Add(new Point(i, j));
                }
            }

            var plants = allAgents.Where(a => a.AgentType == AgentTypes.Plant).ToList();

            for (int i = 0; i < plants.Count; i++)
                AllPoints.RemoveAll(p => plants[i].AgentLocation.X == p.X && plants[i].AgentLocation.Y == p.Y);

            List<Point> pointsToRemove = new List<Point>();
            for (int i = 0; i < AllPoints.Count; i++)
            {
                var agents = allAgents.Where(a => a.AgentLocation.X == AllPoints[i].X && a.AgentLocation.Y == AllPoints[i].Y);

                if (agents.Count() >= 2)
                    pointsToRemove.Add(new Point(AllPoints[i].X, AllPoints[i].Y));
            }

            for(int i = 0; i < pointsToRemove.Count; i++)
                AllPoints.RemoveAll(p => p.X == pointsToRemove[i].X && p.Y == pointsToRemove[i].Y);
            
            int index = rand.Next(0, AllPoints.Count - 1);

            var newP = new Point(AllPoints.ElementAt(index).X, AllPoints.ElementAt(index).Y);
            var network = currentAgent.GetNetwork();

            // якщо предок травоїдне, то створюємо нового травоїдного
            if (currentAgent.AgentType == AgentTypes.Herbivorous)
                agent = new Herbivorous(newP, currentAgent.GetGeneration() + 1, new NeuralNetwork(network));
            
            // якщо предок хижак - створюємо нового хижака
            else
                agent = new Predator(newP, currentAgent.GetGeneration() + 1, new NeuralNetwork(network));
         
            return agent;
        }

        public List<Agent> GenerateAgents()
        {

            List<Agent> agents = new List<Agent>();

            agents.AddRange(GeneratePlants());
            agents.AddRange(GenerateHerbivorous());
            agents.AddRange(GeneratePredators());

            return agents;
        }

        private List<Agent> GeneratePlants()
        {
            List<Agent> plants = new List<Agent>();
            for(int i = 0; i < amountOfPlants; i++)
            {
                int index = rand.Next(0, AllPoints.Count() - 1);

                int X = AllPoints.ElementAt(index).X;
                int Y = AllPoints.ElementAt(index).Y;

                Agent plant = new Plant(new Point(X, Y));
                plants.Add(plant);
                AllPoints.RemoveAt(index);
            }
            return plants;
        }

        private List<Agent> GenerateHerbivorous()
        {
            List<Point> herbivorousList = new List<Point>();
            herbivorousList.AddRange(AllPoints);

            List<Agent> herbivores = new List<Agent>();
            for (int i = 0; i < amountOfHerbivorous; i++)
            {
                int index = rand.Next(0, herbivorousList.Count() - 1);

                int X = herbivorousList.ElementAt(index).X;
                int Y = herbivorousList.ElementAt(index).Y;

                Agent herbivorous = new Herbivorous(new Point(X, Y), 1, new NeuralNetwork());
                herbivores.Add(herbivorous);
                herbivorousList.RemoveAt(index);
            }
            return herbivores;
        }

        private List<Agent> GeneratePredators()
        {
            List<Agent> predators = new List<Agent>();
            for (int i = 0; i < amountOfPredators; i++)
            {
                int index = rand.Next(0, AllPoints.Count() - 1);

                int X = AllPoints.ElementAt(index).X;
                int Y = AllPoints.ElementAt(index).Y;

                Agent predator = new Predator(new Point(X, Y), 1, new NeuralNetwork());
                predators.Add(predator);
                AllPoints.RemoveAt(index);

            }
            return predators;
        }

    }
}
