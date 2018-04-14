using Lab2.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BaseNetwork
{
    public class NeuralNetwork
    {
        // ваги мережі
        private double[][] weights;
        // коефіцієнт зсуву для виходів мережі
        private double[] bias;
        // кількість входів
        private const int inputsNum = 12;
        // кількість виходів
        private const int outputsNum = 4;
        // кількість випадкових ваг, які піддаються мутації
        private const int mutationNum = 8;

        Random rand;

        public NeuralNetwork(NeuralNetwork oldNetwork)
        {
            rand = new Random();
            weights = new double[inputsNum][];
            for (int i = 0; i < inputsNum; i++)
                weights[i] = new double[outputsNum];

            bias = new double[outputsNum];

            for (int i = 0; i < inputsNum; i++)
            {
                for (int j = 0; j < outputsNum; j++)
                {
                    weights[i][j] = oldNetwork.weights[i][j];
                }
            }
        }

        public NeuralNetwork()
        {
            rand = new Random();
            weights = new double[inputsNum][];
            for (int i = 0; i < inputsNum; i++)
                weights[i] = new double[outputsNum];

            bias = new double[outputsNum];

            for (int i = 0; i < inputsNum; i++)
            {
                for (int j = 0; j < outputsNum; j++)
                {
                    weights[i][j] = Gaussian.GetRandomGaussian();
                }
            }

            for (int i = 0; i < outputsNum; i++)
                bias[i] = Gaussian.GetRandomGaussian();        
        }

        public AgentAction ChooseAction(int[] inputs)
        {
            int winner = CalculateAnswer(inputs);
            AgentAction action = AgentAction.TurnLeft;
            switch (winner)
            {
                case 0:
                    {
                        action = AgentAction.TurnLeft;
                        break;
                    }
                case 1:
                    {
                        action = AgentAction.TurnRight;
                        break;
                    }
                case 2:
                    {
                        action = AgentAction.Move;
                        break;
                    }
                case 3:
                    {
                        action = AgentAction.Eat;
                        break;
                    }
                default:
                    break;
            }
            return action;
        }

        private int CalculateAnswer(int[] inputs)
        {
            double[] outputs = new double[outputsNum];
            for(int i = 0; i < outputsNum; i++)
            {
                double sum = 0.0;
                for(int j = 0; j < inputsNum; j++)
                    sum += weights[j][i] * inputs[j];

                outputs[i] = sum + bias[i];
            }

            double maxValue = outputs.Max();
            return outputs.ToList().IndexOf(maxValue);
        }

        public void Mutation()
        {
            var weightsList = new List<double>();
            for (int i = 0; i < inputsNum; i++)
            {
                for (int j = 0; j < outputsNum; j++)
                {
                    weightsList.Add(weights[i][j]);
                }
            }

            for (int i = 0; i < mutationNum; i++)
            {
                int index = rand.Next(0, weightsList.Count - 1);
                int iIndex = index / outputsNum;
                int jIndex = index % outputsNum;
                weights[iIndex][jIndex] = Gaussian.GetRandomGaussian();
                weightsList.RemoveAt(index);
            }
            

        }
    }

    // Клас для створення випадкових чисел з нормальним розподілом
    public static class Gaussian
    {
        private static Random gen = new Random();

        public static double GetRandomGaussian()
        {
            return GetRandomGaussian(0.0, 1.0);
        }

        public static double GetRandomGaussian(double mean, double stddev)
        {
            double rVal1, rVal2;
            GetRandomGaussian(mean, stddev, out rVal1, out rVal2);
            return rVal1;
        }

        public static void GetRandomGaussian(double mean, double stddev, out double val1, out double val2)
        {
            double u, v, s, t;

            do
            {
                u = 2 * gen.NextDouble() - 1;
                v = 2 * gen.NextDouble() - 1;
            } while (u * u + v * v > 1 || (u == 0 && v == 0));

            s = u * u + v * v;
            t = Math.Sqrt((-2.0 * Math.Log(s)) / s);

            val1 = stddev * t * u + mean;
            val2 = stddev * t * v + mean;


        }
    }
}
