using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyArduinoUno
{
    public partial class Form2 : Form
    {

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public int inputStream;
        private Form1 form1;
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            updateTimer();
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            setRange();
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            FormClosing += Form2_FormClosing;


        }
        private void setRange()
        {
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = chart1.ChartAreas["ChartArea1"].AxisX.Minimum + (int) this.axisRange.Value;
        }

        private void updateTimer()
        { 
            if (myTimer.Enabled) { myTimer.Stop(); }
            myTimer.Interval = (int) this.updateRate.Value;;
            myTimer.Start();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myTimer.Stop();
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            this.BeginInvoke(new EventHandler(IntervalTasks));
        }

        private void IntervalTasks(object sender, EventArgs e)
        {
            switch (inputStream)
            {
                case 0:
                    chart1.Series["InputX"].Points.AddY(form1.valueA0);
                    if (chart1.Series["InputX"].Points.Count > chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.Maximum += 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.Minimum += 1;
                    }
                    break;
                case 1:
                    chart1.Series["InputX"].Points.AddY(form1.valueA1);
                    if (chart1.Series["InputX"].Points.Count > chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.Maximum += 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.Minimum += 1;
                    }
                    break;
                case 2:
                    chart1.Series["InputX"].Points.AddY(form1.valueA2);
                    if (chart1.Series["InputX"].Points.Count > chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.Maximum += 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.Minimum += 1;
                    }
                    break;
                case 3:
                    chart1.Series["InputX"].Points.AddY(form1.valueA3);
                    if (chart1.Series["InputX"].Points.Count > chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.Maximum += 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.Minimum += 1;
                    }
                    break;
                case 4:
                    chart1.Series["InputX"].Points.AddY(form1.valueA4);
                    if (chart1.Series["InputX"].Points.Count > chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.Maximum += 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.Minimum += 1;
                    }
                    break;
                case 5:
                    chart1.Series["InputX"].Points.AddY(form1.valueA5);
                    if (chart1.Series["InputX"].Points.Count > chart1.ChartAreas["ChartArea1"].AxisX.Maximum * 0.8)
                    {
                        chart1.ChartAreas["ChartArea1"].AxisX.Maximum += 1;
                        chart1.ChartAreas["ChartArea1"].AxisX.Minimum += 1;
                    }
                    break;
            }
        }

        private void updateRate_ValueChanged(object sender, EventArgs e)
        {
            updateTimer();
        }

        private void axisRange_ValueChanged(object sender, EventArgs e)
        {
            setRange();
        }
    }
}
