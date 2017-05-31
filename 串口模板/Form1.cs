using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口模板
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        Thread t;
        public serial serial = new serial();

        private void button1_Click(object sender, EventArgs e)
        {
            serial.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial.serialPort1.DataReceived += serial.serialPort1_DataReceived;
            t = new Thread(showtxt);
            t.Start();
        }

        private void showtxt()
        {
            while (true)
            {
                if (serial.SerialReceivedStr != null)
                {
                    textBox3.AppendText(serial.SerialReceivedStr);
                    serial.SerialReceivedStr = null;
                }
                Thread.Sleep(10);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.SerialWriteEvent += Form2_SerialWriteEvent;
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serial.serialPort1.IsOpen)
            {
                serial.serialPort1.Write("123123");
            }
            else
            {
                MessageBox.Show("请打开串口！");
            }
        }

        public void Form2_SerialWriteEvent(string s)
        {
            if (!serial.serialPort1.IsOpen)
            {
                serial.serialPort1.Open();                             
            }
            serial.serialPort1.Write(s);
        }
    }
}
