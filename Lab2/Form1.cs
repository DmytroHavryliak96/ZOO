using Lab2.Services.Drawing;
using Lab2.World;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private Stopwatch sw;
        public WorldSimulation simulation;
        public DrawService drawing;
        private const int width = 45;

        public Form1()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simulation = new WorldSimulation();
            drawing = new DrawService(simulation.WorldSize);
            sw = Stopwatch.StartNew();
            simulation.RunSimulation();
            sw.Stop();

            var time = sw.ElapsedMilliseconds;
            simulation.statistic.AlgorithmTime = time;

            var table = drawing.ConstructDataTable(simulation.allAgents);
            this.worldView.DataSource = table;
            for (int i = 0; i < worldView.ColumnCount; i++)
                worldView.Columns[i].Width = width;
           
            MessageBox.Show($"Simulation is completed.");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (simulation == null)
            {
                MessageBox.Show("First run simulation");
            }
            else
            {
                StatisticForm statForm = new StatisticForm(simulation.statistic, drawing);

                statForm.ShowDialog();
            }
        }
    }
}
