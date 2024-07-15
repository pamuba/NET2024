using CalcServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT_W1
{
    public partial class Form1 : Form
    {
        private ICalcService CalcService_basicHttpBinding = null;
        public Form1()
        {
            InitializeComponent();
            CalcService_basicHttpBinding = new ChannelFactory<CalcServiceLibrary.ICalcService>
             ("CalcService_netTcpBinding").CreateChannel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            //WCFLibrary.MyNumbers obj = new WCFLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = CalcService_basicHttpBinding.Mult(obj).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = CalcService_basicHttpBinding.Div(obj).ToString();
        }
    }
}
