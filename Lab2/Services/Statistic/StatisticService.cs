using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Statistic
{
    public class StatisticService
    {
        // кількість ітерацій під час симуляції
        public int Iterations { get; private set; }

        // максимальний вік Травоїдних за весь час моделювання
        public int MaxAgeHerbivirous { get; private set; }

        // максимальний вік Хижаків за весь час моделювання
        public int MaxAgePredators { get; private set; }

        // кількість Травоїдних на кожній 100-тій ітерації
        public Dictionary<int, int> HerbivirousCount { get; private set; }

        // кількість Хижаків на кожній 100-тій ітерації
        public Dictionary<int, int> PredatorCount { get; private set; }

        // кількість розмножень Травоїдних
        public int HerbivirousReproductionCount { get; private set; }

        // кількість розмножень Хижаків
        public int PredatorReproductionCount { get; private set; }

        // Відсоток Травоїдних на кожній 100-тій ітерації
        public Dictionary<int, double> HerbivirousRate { get; private set; }

        // Відсоток Хижаків на кожній 100-тій ітерації
        public Dictionary<int, double> PredatorRate { get; private set; }

        // час роботи алгоритму у мілісекундах
        public long AlgorithmTime { get; set; }

        public StatisticService()
        {
            AlgorithmTime = 0;
            Iterations = 0;
            MaxAgeHerbivirous = 0;
            MaxAgePredators = 0;

            HerbivirousReproductionCount = 0;
            PredatorReproductionCount = 0;

            HerbivirousCount = new Dictionary<int, int>();
            PredatorCount = new Dictionary<int, int>();

            HerbivirousRate = new Dictionary<int, double>();
            PredatorRate = new Dictionary<int, double>();
        }

        public void SetMaxAge(List<Agent> agents)
        {
            int currentMaxHerbivirousAge = agents.Where(a => a.AgentType == AgentTypes.Herbivorous).Max(h => h.GetAge());
            int currentMaxPredatorsAge = agents.Where(a => a.AgentType == AgentTypes.Predator).Max(p => p.GetAge());

            if (MaxAgeHerbivirous < currentMaxHerbivirousAge)
                MaxAgeHerbivirous = currentMaxHerbivirousAge;

            if (MaxAgePredators < currentMaxPredatorsAge)
                MaxAgePredators = currentMaxPredatorsAge;
        }

        public void AddAgentsCount(List<Agent> allAgents, int currentIteration)
        {
            var herbivirous = allAgents.Where(a => a.AgentType == AgentTypes.Herbivorous).Count();
            var predators = allAgents.Where(a => a.AgentType == AgentTypes.Predator).Count();

            HerbivirousCount.Add(currentIteration, herbivirous);
            PredatorCount.Add(currentIteration, predators);
        }

        public void IncreaseIterations()
        {
            Iterations += 1;
        }

        public void IncreaseReproduction(Agent current)
        {
            if (current.AgentType == AgentTypes.Herbivorous)
                HerbivirousReproductionCount += 1;
            else
                PredatorReproductionCount += 1;
        }

        public void AddAgentsRate(List<Agent> allAgents, int currentIteration)
        {
            var herbivirous = allAgents.Where(a => a.AgentType == AgentTypes.Herbivorous).Count();
            var predators = allAgents.Where(a => a.AgentType == AgentTypes.Predator).Count();

            double herbivirousRate = (double)herbivirous / (double)allAgents.Count();
            double predatorsRate = (double)predators / (double)allAgents.Count();

            HerbivirousRate.Add(currentIteration, herbivirousRate);
            PredatorRate.Add(currentIteration, predatorsRate);
        }

    }
}
