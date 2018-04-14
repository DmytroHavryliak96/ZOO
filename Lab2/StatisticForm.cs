using Lab2.Services.Drawing;
using Lab2.Services.Statistic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class StatisticForm : Form
    {
        public StatisticService service;
        public DrawService draw;
        public StatisticForm(StatisticService current, DrawService drawing)
        {
            InitializeComponent();
            service = current;
            draw = drawing;

            this.chart1.ChartAreas[0].AxisX.Title = "ітерація";
            this.chart1.ChartAreas[0].AxisY.Title = "кількість агентів";

            DataBinding();
        }

        private void DataBinding()
        {
            DataTable table = draw.ConstructStatisticTable(service);
            this.dataGridView1.DataSource = table;

            this.Iterations.Text = service.Iterations.ToString();
            this.Time.Text = service.AlgorithmTime.ToString();

            this.RepHerbivirous.Text = service.HerbivirousReproductionCount.ToString();
            this.RepPredators.Text = service.PredatorReproductionCount.ToString();

            this.MaxAgeHerbivirous.Text = service.MaxAgeHerbivirous.ToString();
            this.MaxAgePredators.Text = service.MaxAgePredators.ToString();

            for (int i = 0; i < service.HerbivirousCount.Count; i++)
            {
                var xPoint = service.HerbivirousCount.ElementAt(i).Key;
                var yPoint1 = service.HerbivirousCount.ElementAt(i).Value;
                var yPoint2 = service.PredatorCount.ElementAt(i).Value;

                this.chart1.Series["Herbivirous"].Points.AddXY(xPoint, yPoint1);
                this.chart1.Series["Predator"].Points.AddXY(xPoint, yPoint2);

            }
        }
    }
}
