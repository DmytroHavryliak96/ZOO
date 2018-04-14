using Lab2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Generating;
using Lab2.Services.Filter;
using Lab2.Services;
using Lab2.Areas;
using Lab2.Services.TurnAgent;
using Lab2.Services.Sensor;
using Lab2.Services.Statistic;

namespace Lab2.World
{
    // дії, які агент може виконати
    public enum AgentAction
    {
        Move,
        Eat,
        TurnRight,
        TurnLeft
    }

    public class WorldSimulation : ISimulation
    {
        private const int reproductionLevel = 90;
        private const double criticalRate = 0.1;

        public int WorldSize;

        public Generate generator;
        public List<Agent> allAgents;
        private Agent currentAgent;

        // сервіси
        private FilterService filterService;
        private LocationServiceBuilder locationBuilder;
        private TurnService turnService;
        public SensorService sensorService;
        private Random rand;
        public StatisticService statistic;

        public WorldSimulation()
        {
            WorldSize = Convert.ToInt32(Settings.Default.WorldSize);
         
            generator = new Generate(WorldSize);
            AddAllAgents(generator.GenerateAgents());

            // ініціалізація сервісів
            filterService = new FilterService();
            locationBuilder = new LocationServiceBuilder();
            turnService = new TurnService();
            sensorService = new SensorService();
            statistic = new StatisticService();
            rand = new Random();
            
        }

        // додати всіх агентів
        public void AddAllAgents(List<Agent> agents)
        {
            allAgents = agents;
        }

        // змінюємо координати агента якщо є вільні чарунки
        private void MoveAgent()
        {
            var locationService = locationBuilder.getLocationService(currentAgent.AgentLocation, currentAgent.Direction);
            // Якщо можливо переміститись у вільний чарунок, то переміщаємо агента
            Point dest = locationService.getPositionToMove();
            var agents = allAgents.Where(a => a.AgentLocation.X == dest.X && a.AgentLocation.Y == dest.Y);
            if (agents.Count() >= 2)
            {
                TurnAgentLeft();
            }
            else if (agents.Where(a => a.AgentType == AgentTypes.Plant).Count() >= 1)
            {
               
                TurnAgentLeft();
            }
            else
            {
                currentAgent.MoveAgent(dest);
            }
            
        }

        // повернути агента вліво
        private void TurnAgentLeft()
        {
            currentAgent.Direction = turnService.getSightDirectionLeft(currentAgent.Direction);
        }

        // повернути агента вправо
        private void TurnAgentRight()
        {
            currentAgent.Direction = turnService.getSightDirectionRight(currentAgent.Direction);
        }

        // з'їсти іншого агента відповідно до харчового ланцюгу
        private void EatAgent()
        {
            var locationService = locationBuilder.getLocationService(currentAgent.AgentLocation, currentAgent.Direction);
            var points = locationService.getProximityPoints().ToList();
            var agentToEat = sensorService.getAgentToEat(allAgents, points, currentAgent);

            if (agentToEat != null)
            {
                currentAgent.Eat();
                allAgents.Remove(agentToEat);
                // якщо з'їджений агент - це рослина, то генеруємо автоматично нову
                if(agentToEat.AgentType == AgentTypes.Plant)
                    allAgents.Add(generator.GenerateNewPlant(allAgents));
            }
            else
            {
                TurnAgentLeft();
            }
           
        }

        // функція відтворення
        private void Reproduce()
        {  
                currentAgent.Reproduction();
                var newAMigratingAgent = generator.GenerateNewMigratingAgent(allAgents, currentAgent);
                newAMigratingAgent.GetNetwork().Mutation();
                allAgents.Add(newAMigratingAgent);
            
        }

        // агент вибирає, яку дію виконати
        private void TakeAgentAction()
        {
            var locationService = locationBuilder.getLocationService(currentAgent.AgentLocation, currentAgent.Direction);
            var inputs = sensorService.GetInputsForNetwork(allAgents, currentAgent, locationService);
            AgentAction action = currentAgent.GetNetwork().ChooseAction(inputs);

            switch (action)
            {
                case AgentAction.Move:
                    {
                        MoveAgent();
                        break;
                    }
                case AgentAction.Eat:
                    {
                        EatAgent();
                       
                        break;
                    }
                case AgentAction.TurnRight:
                    {
                        TurnAgentRight();
                        break;
                    }
                case AgentAction.TurnLeft:
                    {
                        TurnAgentLeft();
                        break;
                    }
                default:
                    break;
            }
        }

        // метаболізм
        private void Metabolism()
        {
            currentAgent.ReduceEnergy();
        }

        // змінюємо поточного агента
        private void setCurrentAgent()
        {
            var migratingAll = filterService.getMigratingAgents(allAgents);
            int index = rand.Next(0, migratingAll.Count);
            currentAgent = migratingAll.ElementAt(index);
        }

        // збільшуємо вік мігруючих агентів, які прожили поточну ітерацію і вижили
        private void IncreaseAge()
        {
            var migratingAll = filterService.getMigratingAgents(allAgents);
            for(int i = 0; i < migratingAll.Count; i++)
                migratingAll[i].IncreseAge();
            
        }

        // перевірка, чи відсоток популяції одного з типів мігруючих агентів менше 10 %
        private bool ContinueAlgorithm()
        {
            var allHerbivirous = allAgents.Where(a => a.AgentType == AgentTypes.Herbivorous);
            var allPredators = allAgents.Where(a => a.AgentType == AgentTypes.Predator);

            double herbivirousRate = (double)allHerbivirous.Count() / (double)allAgents.Count();
            double predatorsRate = (double)allPredators.Count() / (double)allAgents.Count();

            if (herbivirousRate < criticalRate || predatorsRate < criticalRate)
                return false;

            return true;
        }

        // запуск симуляції
        public void RunSimulation()
        {
            while (ContinueAlgorithm())
            {
                setCurrentAgent();
                RunIteration();
                statistic.IncreaseIterations();
                if (statistic.Iterations % 100 == 0)
                {
                    statistic.AddAgentsCount(allAgents, statistic.Iterations);
                    statistic.AddAgentsRate(allAgents, statistic.Iterations);
                }
            }
        }

        // запуск ітерації для поточного мігруючого агента
        public void RunIteration()
        {
            TakeAgentAction();
            if (currentAgent.GetEnergyLevel() >= reproductionLevel)
            {
                Reproduce();
                statistic.IncreaseReproduction(currentAgent);
            }
            else
                Metabolism();

            if (currentAgent.IsAlive() == false)
                allAgents.Remove(currentAgent);
            IncreaseAge();
            statistic.SetMaxAge(allAgents);
        }

        
    }
}
