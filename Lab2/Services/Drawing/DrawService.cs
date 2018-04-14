using Lab2.Services.Statistic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Drawing
{
    public class DrawService
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        //public const int width = 20;

        public DrawService(int worldsize)
        {
            Rows = Columns = worldsize;
        }

        // сторення таблиці для відображення агентів 
        public DataTable ConstructDataTable(List<Agent> allAgents)
        {
            DataTable world = new DataTable();
            for (int i = 0; i < Columns; i++)
                world.Columns.Add(i.ToString());
            
            for(int i = 0; i < Rows; i++)
            {
                DataRow row = world.NewRow();
                world.Rows.Add(row);
            }

            foreach(var agent in allAgents)
            {
                int x = agent.AgentLocation.X;
                int y = agent.AgentLocation.Y;
                world.Rows[y][x] += FormatString(agent);
            }


            return world;
            
        }

        // створення таблиці для відображення статистичної таблиці
        public DataTable ConstructStatisticTable(StatisticService service)
        {
            var table = new DataTable();
            table.Columns.Add("Ітерація");
            table.Columns.Add("Кількість Травоїдних");
            table.Columns.Add("Кількість Хижаків");
            table.Columns.Add("Відсоток Травоїдних");
            table.Columns.Add("Відсоток Хижаків");

            for(int i = 0; i < service.HerbivirousCount.Count; i++)
            {
                DataRow row = table.NewRow();
                row["Ітерація"] = service.HerbivirousCount.ElementAt(i).Key;
                row["Кількість Травоїдних"] = service.HerbivirousCount.ElementAt(i).Value;
                row["Кількість Хижаків"] = service.PredatorCount.ElementAt(i).Value;
                row["Відсоток Травоїдних"] = service.HerbivirousRate.ElementAt(i).Value;
                row["Відсоток Хижаків"] = service.PredatorRate.ElementAt(i).Value;
                table.Rows.Add(row);
            }

            return table;
        }

        private string FormatString(Agent currentAgent)
        {
            string answer = "";
            string AgentType = currentAgent.AgentType.ToString();
            string AgentDirection = currentAgent.Direction.ToString();
            answer += AgentType;
            answer += "-" + AgentDirection + "; ";
            return answer;
        }


    }
}
