using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections;

namespace MyArduinoUno
{
    public partial class Form1 : Form
    {
        public SerialPort myport = new SerialPort();
        private String data_rx;

        // Input or Output of Pins
        private bool? isInputPIN0 = null;
        private bool? isInputPIN1 = null;
        private bool? isInputPIN2 = null;
        private bool? isInputPIN3 = null;
        private bool? isInputPIN4 = null;
        private bool? isInputPIN5 = null;
        private bool? isInputPIN6 = null;
        private bool? isInputPIN7 = null;
        private bool? isInputPIN8 = null;
        private bool? isInputPIN9 = null;
        private bool? isInputPIN10 = null;
        private bool? isInputPIN11 = null;
        private bool? isInputPIN12 = null;
        private bool? isInputPIN13 = null;
        private bool? isInputPINA0 = null;
        private bool? isInputPINA1 = null;
        private bool? isInputPINA2 = null;
        private bool? isInputPINA3 = null;
        private bool? isInputPINA4 = null;
        private bool? isInputPINA5 = null;
        
        // High or Low Pins
        private bool isHighPIN0 = false;
        private bool isHighPIN1 = false;
        private bool isHighPIN2 = false;
        private bool isHighPIN3 = false;
        private bool isHighPIN4 = false;
        private bool isHighPIN5 = false;
        private bool isHighPIN6 = false;
        private bool isHighPIN7 = false;
        private bool isHighPIN8 = false;
        private bool isHighPIN9 = false;
        private bool isHighPIN10 = false;
        private bool isHighPIN11 = false;
        private bool isHighPIN12 = false;
        private bool isHighPIN13 = false;
        private bool isHighPINA0 = false;
        private bool isHighPINA1 = false;
        private bool isHighPINA2 = false;
        private bool isHighPINA3 = false;
        private bool isHighPINA4 = false;
        private bool isHighPINA5 = false;

        public int valueA0 = 0;
        public int valueA1 = 0;
        public int valueA2 = 0;
        public int valueA3 = 0;
        public int valueA4 = 0;
        public int valueA5 = 0;

        public Form1()
        {
            InitializeComponent();
            fillPorts();
            fillBaudrate();
            myport.DataReceived += myport_DataReceived;
            FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myport.Close();
        }

        private void fillPorts()
        {
            //Adds active Ports to 
            String[] ports;
            ports = System.IO.Ports.SerialPort.GetPortNames();
            cbPorts.Items.AddRange(ports);
        }

        private void fillBaudrate()
        {
            Object[] baudrates = {300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200};
            cbBaudrate.Items.AddRange(baudrates);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (cbPorts.Text == "" | cbBaudrate.Text == "")
            {
                MessageBox.Show("Bitte vorher die Auswahl des Ports und der Baudrate durchführen");
            }
            else
            {
                if (myport.IsOpen)
                {
                    myport.Close();
                }
                myport.BaudRate = Int32.Parse(cbBaudrate.Text);
                myport.PortName = cbPorts.Text;
                try
                {
                    myport.Open();
                }
                catch
                {
                    MessageBox.Show("Error: Could not be open serial port!");
                }
                laPin0.Text = (isInputPIN0 == null) ? "" : (isInputPIN0 == true) ? "IN" : "OUT";
                laPin1.Text = (isInputPIN1 == null) ? "" : (isInputPIN1 == true) ? "IN" : "OUT";
                laPin2.Text = (isInputPIN2 == null) ? "" : (isInputPIN2 == true) ? "IN" : "OUT";
                laPin3.Text = (isInputPIN3 == null) ? "" : (isInputPIN3 == true) ? "IN" : "OUT";
                laPin4.Text = (isInputPIN4 == null) ? "" : (isInputPIN4 == true) ? "IN" : "OUT";
                laPin5.Text = (isInputPIN5 == null) ? "" : (isInputPIN5 == true) ? "IN" : "OUT";
                laPin6.Text = (isInputPIN6 == null) ? "" : (isInputPIN6 == true) ? "IN" : "OUT";
                laPin7.Text = (isInputPIN7 == null) ? "" : (isInputPIN7 == true) ? "IN" : "OUT";
                laPin8.Text = (isInputPIN8 == null) ? "" : (isInputPIN8 == true) ? "IN" : "OUT";
                laPin9.Text = (isInputPIN9 == null) ? "" : (isInputPIN9 == true) ? "IN" : "OUT";
                laPin10.Text = (isInputPIN10 == null) ? "" : (isInputPIN10 == true) ? "IN" : "OUT";
                laPin11.Text = (isInputPIN11 == null) ? "" : (isInputPIN11 == true) ? "IN" : "OUT";
                laPin12.Text = (isInputPIN12 == null) ? "" : (isInputPIN12 == true) ? "IN" : "OUT";
                laPin13.Text = (isInputPIN13 == null) ? "" : (isInputPIN13 == true) ? "IN" : "OUT";
                laPinA0.Text = (isInputPINA0 == null) ? "" : (isInputPINA0 == true) ? "AIN" : "OUT";
                laPinA1.Text = (isInputPINA1 == null) ? "" : (isInputPINA1 == true) ? "AIN" : "OUT";
                laPinA2.Text = (isInputPINA2 == null) ? "" : (isInputPINA2 == true) ? "AIN" : "OUT";
                laPinA3.Text = (isInputPINA3 == null) ? "" : (isInputPINA3 == true) ? "AIN" : "OUT";
                laPinA4.Text = (isInputPINA4 == null) ? "" : (isInputPINA4 == true) ? "AIN" : "OUT";
                laPinA5.Text = (isInputPINA5 == null) ? "" : (isInputPINA5 == true) ? "AIN" : "OUT";

                this.ofPin0.Image = (isHighPIN0 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin1.Image = (isHighPIN1 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin2.Image = (isHighPIN2 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin3.Image = (isHighPIN3 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin4.Image = (isHighPIN4 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin5.Image = (isHighPIN5 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin6.Image = (isHighPIN6 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin7.Image = (isHighPIN7 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin8.Image = (isHighPIN8 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin9.Image = (isHighPIN9 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin10.Image = (isHighPIN10 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin11.Image = (isHighPIN11 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin12.Image = (isHighPIN12 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPin13.Image = (isHighPIN13 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPinA0.Image = (isHighPINA0 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPinA1.Image = (isHighPINA1 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPinA2.Image = (isHighPINA2 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPinA3.Image = (isHighPINA3 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPinA4.Image = (isHighPINA4 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                this.ofPinA5.Image = (isHighPINA5 == false) ? global::MyArduinoUno.Properties.Resources.grey_led : global::MyArduinoUno.Properties.Resources.green_led;
                
                /*
                this.progressBarA0.Value = valueA0;
                this.progressBarA1.Value = valueA1;
                this.progressBarA2.Value = valueA2;
                this.progressBarA3.Value = valueA3;
                this.progressBarA4.Value = valueA4;
                this.progressBarA5.Value = valueA5;
                */
            }
        }

        private void tbPinA4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data_rx = myport.ReadLine(); 
            this.BeginInvoke(new EventHandler(updateValues_event));
        }

        private void updateValues_event(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string data = data_rx.Replace(" ","");
            //Console.WriteLine(data_rx);
            string[] test = data.Split(delimiterChars);
            //int i = 0;
            //bool ioDDRD = false;
            //bool highLowInfo = false;
            if (this.checkBox1.Checked)
            {
                tbSerialPort.AppendText(data_rx + "\r\n");
            }
            if (test[0] == "DDRD") // Status of digital PIN 0 - 7 whether INPUT=0 or OUTPUT=1 
            {
                int zahl;
                if (Int32.TryParse(test[1], out zahl))
                {
                    char[] bits = getCharArray(zahl);
                    int check = 0;
                    foreach (char bit in bits)
                    {
                        bool pin = (bit == '1') ? false : true;
                        switch (check)
                        {
                            case 7:     //PIN 0
                                if (pin != isInputPIN0) { laPin0.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN0 = pin;
                                break;
                            case 6:     //PIN 1
                                if (pin != isInputPIN1) { laPin1.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN1 = pin;
                                break;
                            case 5:     //PIN 2
                                if (pin != isInputPIN2) { laPin2.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN2 = pin;
                                break;
                            case 4:     //PIN 3
                                if (pin != isInputPIN3) { laPin3.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN3 = pin;
                                break;
                            case 3:     //PIN 4
                                if (pin != isInputPIN4) { laPin4.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN4 = pin;
                                break;
                            case 2:     //PIN 5
                                if (pin != isInputPIN5) { laPin5.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN5 = pin;
                                break;
                            case 1:     //PIN 6
                                if (pin != isInputPIN6) { laPin6.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN6 = pin;
                                break;
                            case 0:     //PIN 7
                                if (pin != isInputPIN7) { laPin7.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN7 = pin;
                                break;
                        }
                        check++;
                    }
                }
            }

            else if (test[0] == "DDRB") // Status of digital PIN 8 - 13 whether INPUT=0 or OUTPUT=1 
            {
                int zahl;
                if (Int32.TryParse(test[1], out zahl))
                {
                    char[] bits = getCharArray(zahl);
                    int check = 0;
                    foreach (char bit in bits)
                    {
                        bool pin = (bit == '1') ? false : true;
                        switch (check)
                        {
                            case 7:     //PIN 8
                                if (pin != isInputPIN8) { laPin8.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN8 = pin;
                                break;
                            case 6:     //PIN 9
                                if (pin != isInputPIN9) { laPin9.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN9 = pin;
                                break;
                            case 5:     //PIN 10
                                if (pin != isInputPIN10) { laPin10.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN10 = pin;
                                break;
                            case 4:     //PIN 11
                                if (pin != isInputPIN11) { laPin11.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN11 = pin;
                                break;
                            case 3:     //PIN 12
                                if (pin != isInputPIN12) { laPin12.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN12 = pin;
                                break;
                            case 2:     //PIN 13
                                if (pin != isInputPIN13) { laPin13.Text = (pin == false) ? "OUT" : "IN"; }
                                isInputPIN13 = pin;
                                break;
                        }
                        check++;
                    }
                }
            }

            else if (test[0] == "DDRC") // Status of analog PIN 0 - 5 whether INPUT=0 or OUTPUT=1 
            {
                int zahl;
                if (Int32.TryParse(test[1], out zahl))
                {
                    char[] bits = getCharArray(zahl);
                    int check = 0;
                    foreach (char bit in bits)
                    {
                        bool pin = (bit == '1') ? false : true;
                        switch (check)
                        {
                            case 7:     //PIN A0
                                if (pin != isInputPINA0) { laPinA0.Text = (pin == false) ? "OUT" : "AIN"; }
                                isInputPINA0 = pin;
                                break;
                            case 6:     //PIN A1
                                if (pin != isInputPINA1) { laPinA1.Text = (pin == false) ? "OUT" : "AIN"; }
                                isInputPINA1 = pin;
                                break;
                            case 5:     //PIN 2
                                if (pin != isInputPINA2) { laPinA2.Text = (pin == false) ? "OUT" : "AIN"; }
                                isInputPINA2 = pin;
                                break;
                            case 4:     //PIN 3
                                if (pin != isInputPINA3) { laPinA3.Text = (pin == false) ? "OUT" : "AIN"; }
                                isInputPINA3 = pin;
                                break;
                            case 3:     //PIN 4
                                if (pin != isInputPINA4) { laPinA4.Text = (pin == false) ? "OUT" : "AIN"; }
                                isInputPINA4 = pin;
                                break;
                            case 2:     //PIN 5
                                if (pin != isInputPINA5) { laPinA5.Text = (pin == false) ? "OUT" : "AIN"; }
                                isInputPINA5 = pin;
                                break;
                        }
                        check++;
                    }
                }
            }

            else if (test[0] == "PORTD") // Status of digital PIN 0 - 7 whether LOW=0 or HIGH=1
            {
                int zahl;
                if (Int32.TryParse(test[1], out zahl))
                {
                    char[] bits = getCharArray(zahl);
                    int check = 0;
                    foreach (char bit in bits)
                    {
                        bool pin = (bit == '1') ? true : false;
                        switch (check)
                        {
                            case 7:     //PIN 0
                                if (pin != isHighPIN0) { this.ofPin0.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN0 = pin;
                                break;
                            case 6:     //PIN 1
                                if (pin != isHighPIN1) { this.ofPin1.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN1 = pin;
                                break;
                            case 5:     //PIN 2
                                if (pin != isHighPIN2) { this.ofPin2.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN2 = pin;
                                break;
                            case 4:     //PIN 3
                                if (pin != isHighPIN3) { this.ofPin3.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN3 = pin;
                                break;
                            case 3:     //PIN 4
                                if (pin != isHighPIN4) { this.ofPin4.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN4 = pin;
                                break;
                            case 2:     //PIN 5
                                if (pin != isHighPIN5) { this.ofPin5.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN5 = pin;
                                break;
                            case 1:     //PIN 6
                                if (pin != isHighPIN6) { this.ofPin6.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN6 = pin;
                                break;
                            case 0:     //PIN 7
                                if (pin != isHighPIN7) { this.ofPin7.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN7 = pin;
                                break;
                        }
                        check++;
                    }
                }
            }

            else if (test[0] == "PORTB") // Status of digital PIN 8 - 13 whether LOW=0 or HIGH=1
            {
                int zahl;
                if (Int32.TryParse(test[1], out zahl))
                {
                    char[] bits = getCharArray(zahl);
                    int check = 0;
                    foreach (char bit in bits)
                    {
                        bool pin = (bit == '1') ? true : false;
                        switch (check)
                        {
                            case 7:     //PIN 8
                                if (pin != isHighPIN8) { this.ofPin8.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN8 = pin;
                                break;
                            case 6:     //PIN 9
                                if (pin != isHighPIN9) { this.ofPin9.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN9 = pin;
                                break;
                            case 5:     //PIN 10
                                if (pin != isHighPIN10) { this.ofPin10.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN10 = pin;
                                break;
                            case 4:     //PIN 11
                                if (pin != isHighPIN11) { this.ofPin11.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN11 = pin;
                                break;
                            case 3:     //PIN 12
                                if (pin != isHighPIN12) { this.ofPin12.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN12 = pin;
                                break;
                            case 2:     //PIN 13
                                if (pin != isHighPIN13) { this.ofPin13.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPIN13 = pin;
                                break;                        
                        }
                        check++;
                    }
                }
            }

            else if (test[0] == "PORTC") // Status of analog PIN 0 - 5 whether LOW=0 or HIGH=1
            {
                int zahl;
                if (Int32.TryParse(test[1], out zahl))
                {
                    char[] bits = getCharArray(zahl);
                    int check = 0;
                    foreach (char bit in bits)
                    {
                        bool pin = (bit == '1') ? true : false;
                        switch (check)
                        {
                            case 7:     //PIN A0
                                if (pin != isHighPINA0) { this.ofPinA0.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPINA0 = pin;
                                break;
                            case 6:     //PIN A1
                                if (pin != isHighPINA1) { this.ofPinA1.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPINA1 = pin;
                                break;
                            case 5:     //PIN A2
                                if (pin != isHighPINA2) { this.ofPinA2.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPINA2 = pin;
                                break;
                            case 4:     //PIN A3
                                if (pin != isHighPINA3) { this.ofPinA3.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPINA3 = pin;
                                break;
                            case 3:     //PIN A4
                                if (pin != isHighPINA4) { this.ofPinA4.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPINA4 = pin;
                                break;
                            case 2:     //PIN A5
                                if (pin != isHighPINA5) { this.ofPinA5.Image = (pin == true) ? global::MyArduinoUno.Properties.Resources.green_led : global::MyArduinoUno.Properties.Resources.grey_led; }
                                isHighPINA5 = pin;
                                break;
                        }
                        check++;
                    }
                }
            }
            else if (test[0] == "AOVAL")
            {
                int value;
                int.TryParse(test[1], out value);
                if (value != valueA0) { this.progressBarA0.Value = value; }
                valueA0 = value;
            }
            else if (test[0] == "A1VAL")
            {
                int value;
                int.TryParse(test[1], out value);
                if (value != valueA1) { this.progressBarA1.Value = value; }
                valueA1 = value;
            }
            else if (test[0] == "A2VAL")
            {
                int value;
                int.TryParse(test[1], out value);
                if (value != valueA2) { this.progressBarA2.Value = value; }
                valueA2 = value;
            }
            else if (test[0] == "A3VAL")
            {
                int value;
                int.TryParse(test[1], out value);
                if (value != valueA3) { this.progressBarA3.Value = value; }
                valueA3 = value;
            }
            else if (test[0] == "A4VAL")
            {
                int value;
                int.TryParse(test[1], out value);
                if (value != valueA4) { this.progressBarA4.Value = value; }
                valueA4 = value;
            }
            else if (test[0] == "A5VAL")
            {
                int value;
                int.TryParse(test[1], out value);
                if (value != valueA5) { this.progressBarA5.Value = value; }
                valueA5 = value;
            }
            else
            {
                if (!this.checkBox1.Checked)
                {
                    tbSerialPort.AppendText(data_rx + "\r\n");
                }
            }

        }
        private char[] getCharArray(int Integer)
        {
            string str = Convert.ToString(Integer, 2);
            char[] bits = str.PadLeft(8, '0').ToCharArray();
            return bits;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ofPin13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (myport.IsOpen)
            {
                myport.Close();
                this.resetLayout();
            }

         }

        private void cbPWM11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbSerialPort.Text = "";
        }

        private void pBA5_Click(object sender, System.EventArgs e)
        {
            Form2 iographA5 = new Form2(this);
            iographA5.inputStream = 5;
            iographA5.Text = "IO Graph A5";
            iographA5.Show(this);
        }

        private void pBA4_Click(object sender, System.EventArgs e)
        {
            Form2 iographA4 = new Form2(this);
            iographA4.inputStream = 4;
            iographA4.Text = "IO Graph A4";
            iographA4.Show(this);
        }

        private void pBA3_Click(object sender, System.EventArgs e)
        {
            Form2 iographA3 = new Form2(this);
            iographA3.inputStream = 3;
            iographA3.Text = "IO Graph A3";
            iographA3.Show(this);
        }

        private void pBA2_Click(object sender, System.EventArgs e)
        {
            Form2 iographA2 = new Form2(this);
            iographA2.inputStream = 2;
            iographA2.Text = "IO Graph A2";
            iographA2.Show(this);
        }

        private void pBA1_Click(object sender, System.EventArgs e)
        {
            Form2 iographA1 = new Form2(this);
            iographA1.inputStream = 1;
            iographA1.Text = "IO Graph A1";
            iographA1.Show(this);
        }
        
        private void pBA0_Click(object sender, System.EventArgs e)
        {
            Form2 iographA0 = new Form2(this);
            iographA0.inputStream = 0;
            iographA0.Text = "IO Graph A0";
            iographA0.Show(this);
        }

    }
}
