using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口模板
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //定义带参数的委托与事件
        public delegate void Mydelegate(string s);
        public event Mydelegate SerialWriteEvent;

        private void button1_Click(object sender, EventArgs e)
        {        
            SerialWriteEvent(textBox1.Text);
        }      
    }
}
