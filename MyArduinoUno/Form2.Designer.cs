namespace MyArduinoUno
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.updateRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axisRange = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisRange)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisY.Interval = 200D;
            chartArea1.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(0, 33);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "InputX";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(643, 246);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // updateRate
            // 
            this.updateRate.Location = new System.Drawing.Point(84, 7);
            this.updateRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updateRate.Name = "updateRate";
            this.updateRate.Size = new System.Drawing.Size(65, 20);
            this.updateRate.TabIndex = 1;
            this.updateRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.updateRate.ValueChanged += new System.EventHandler(this.updateRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Update rate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Range:";
            // 
            // axisRange
            // 
            this.axisRange.Location = new System.Drawing.Point(211, 7);
            this.axisRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.axisRange.Name = "axisRange";
            this.axisRange.Size = new System.Drawing.Size(65, 20);
            this.axisRange.TabIndex = 3;
            this.axisRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.axisRange.ValueChanged += new System.EventHandler(this.axisRange_ValueChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 279);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.axisRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateRate);
            this.Controls.Add(this.chart1);
            this.Name = "Form2";
            this.Text = "IO Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axisRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown updateRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown axisRange;
    }
}