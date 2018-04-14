using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.BaseNetwork;
using Lab2.Areas;
using Lab2.Services;

namespace Lab2
{
    // існуючі напрямки погляду
    public enum SightDirection
    {
        North,
        South,
        East,
        West,
        None
    }

    public enum AgentTypes
    {
        Plant,
        Herbivorous,
        Predator
    }

    public abstract class Agent
    {
        
        // тип агента
        public AgentTypes AgentType;

        // координати агента
        public Point AgentLocation { get; set; }

        public Agent(Point currentLocation)
        {
            AgentLocation = currentLocation;
        }

        //  напрям погляду
        public SightDirection Direction { get; set; }
        // рух агента
        public abstract void MoveAgent(Point destination);
        public abstract void Eat();
        public abstract void Reproduction();
        public abstract NeuralNetwork GetNetwork();
        // збільшити вік агента
        public abstract void IncreseAge();
        public abstract int GetGeneration();

        public abstract bool IsAlive();

        public abstract void ReduceEnergy();

        public abstract int GetEnergyLevel();

        public abstract int GetAge();

    }

    public class MigratingAgent : Agent
    {
        // рівень енергії, яку агент отримує за поглинання іншого
        public int EatingEnergy { get; protected set; }
        // метаболізм агенту
        public int Metabolism { get; protected set; }
        // чи є агент хижаком
        public bool IsPredator { get; set; }
        // рівень енергії агента
        public int EnergyLevel { get; set; }
        // вік агента (скільки ітерацій жив агент) 
        public int Age { get; set; }
        // покоління агента
        public int Generation { get; set; }

        // нейронна мережа
        public NeuralNetwork network { get; set; }
        // фронтальні точки сенсорної зони агента
        public Point[] FrontPoints;
        // ліві точки сенсорної зони
        public Point[] LeftPoints;
        // праві точки сенсорної зони
        public Point[] RightPoints;
        // близькі точки сенсорної зони
        public Point[] ProximityPoints;
        
        public MigratingAgent(Point currentLocation, int generation, NeuralNetwork network) : base(currentLocation)
        {
            this.Generation = generation;
            this.Age = 0;
            this.EnergyLevel = 50;
            this.network = network;
        }

        public override void MoveAgent(Point destination)
        {
            this.AgentLocation.X = destination.X;
            this.AgentLocation.Y = destination.Y;
        }

        public override void ReduceEnergy()
        {
            this.EnergyLevel -= Metabolism;
        }

        public override bool IsAlive()
        {
            if (EnergyLevel <= 0)
                return false;
            else
                return true;
        }

        public override void Eat()
        {
            EnergyLevel += EatingEnergy;
            if (EnergyLevel > 100)
                EnergyLevel = 100;
        }

        public override void Reproduction()
        {
            EnergyLevel /= 2;
        }

        public override NeuralNetwork GetNetwork()
        {
            return this.network;
        }

        public override int GetGeneration()
        {
            return this.Generation;
        }

        public override int GetEnergyLevel()
        {
            return this.EnergyLevel;
        }

        public override void IncreseAge()
        {
            this.Age += 1;
        }

        public override int GetAge()
        {
            return this.Age;
        }
    }
}
