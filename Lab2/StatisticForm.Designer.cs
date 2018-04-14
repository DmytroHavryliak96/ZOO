namespace Lab2
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Iterations = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RepHerbivirous = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RepPredators = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxAgeHerbivirous = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MaxAgePredators = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(356, 190);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Статистична таблиця";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Кількість ітерацій";
            // 
            // Iterations
            // 
            this.Iterations.Location = new System.Drawing.Point(40, 279);
            this.Iterations.Name = "Iterations";
            this.Iterations.ReadOnly = true;
            this.Iterations.Size = new System.Drawing.Size(100, 20);
            this.Iterations.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Час роботи алгоритму (ms)";
            // 
            // Time
            // 
            this.Time.Location = new System.Drawing.Point(244, 279);
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Size = new System.Drawing.Size(100, 20);
            this.Time.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Кількість розмножень Травоїдних";
            // 
            // RepHerbivirous
            // 
            this.RepHerbivirous.Location = new System.Drawing.Point(146, 338);
            this.RepHerbivirous.Name = "RepHerbivirous";
            this.RepHerbivirous.ReadOnly = true;
            this.RepHerbivirous.Size = new System.Drawing.Size(100, 20);
            this.RepHerbivirous.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Кількість розмножень Хижаків";
            // 
            // RepPredators
            // 
            this.RepPredators.Location = new System.Drawing.Point(146, 405);
            this.RepPredators.Name = "RepPredators";
            this.RepPredators.ReadOnly = true;
            this.RepPredators.Size = new System.Drawing.Size(100, 20);
            this.RepPredators.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "Максимальний вік Травоїдних \r\nза весь час моделювання";
            // 
            // MaxAgeHerbivirous
            // 
            this.MaxAgeHerbivirous.Location = new System.Drawing.Point(478, 80);
            this.MaxAgeHerbivirous.Name = "MaxAgeHerbivirous";
            this.MaxAgeHerbivirous.ReadOnly = true;
            this.MaxAgeHerbivirous.Size = new System.Drawing.Size(100, 20);
            this.MaxAgeHerbivirous.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 26);
            this.label7.TabIndex = 12;
            this.label7.Text = "Максимальний вік Хижаків \r\nза весь час моделювання";
            // 
            // MaxAgePredators
            // 
            this.MaxAgePredators.Location = new System.Drawing.Point(675, 80);
            this.MaxAgePredators.Name = "MaxAgePredators";
            this.MaxAgePredators.ReadOnly = true;
            this.MaxAgePredators.Size = new System.Drawing.Size(100, 20);
            this.MaxAgePredators.TabIndex = 13;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(388, 152);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "Herbivirous";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Predator";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(482, 317);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(511, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Кількість агентів через кожну 100-ту ітерацію";
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 481);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.MaxAgePredators);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MaxAgeHerbivirous);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RepPredators);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RepHerbivirous);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Iterations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Iterations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RepHerbivirous;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox RepPredators;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MaxAgeHerbivirous;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MaxAgePredators;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label8;
    }
}