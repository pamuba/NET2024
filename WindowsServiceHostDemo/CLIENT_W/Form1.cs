using MathServiceLibrary;
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


namespace CLIENT_W
{
    public partial class Form1 : Form
    {
        private IMathService netTcpChannel = null;
        public Form1()
        {
            InitializeComponent();
            //var endPoint = new EndpointAddress("net.tcp://localhost:6666/MathService");
            //netTcpChannel = ChannelFactory<IMathService>.CreateChannel(new NetTcpBinding(), endPoint);
            netTcpChannel = new ChannelFactory<MathServiceLibrary.IMathService>("MathService_netTcpBinding").CreateChannel();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = netTcpChannel.Adds(obj).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(textBox1.Text);
            obj.Number2 = Convert.ToInt32(textBox2.Text);

            textBox3.Text = netTcpChannel.Subtracts(obj).ToString();
        }
    }
}
