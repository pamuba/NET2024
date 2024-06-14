using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
	public partial class Form1 : Form
	{
		MathServiceReference.MathServiceClient serviceClient = new MathServiceReference.MathServiceClient();
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MathServiceReference.MyNumbers nums = new MathServiceReference.MyNumbers();
			nums.Number1 = Convert.ToInt32(textBox1.Text);
			nums.Number2 = Convert.ToInt32(textBox2.Text);
			label1.Text = "RESULT: ";
			label1.Text += serviceClient.Add(nums).ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MathServiceReference.MyNumbers nums = new MathServiceReference.MyNumbers();
			nums.Number1 = Convert.ToInt32(textBox1.Text);
			nums.Number2 = Convert.ToInt32(textBox2.Text);
			label1.Text = "RESULT: ";
			label1.Text += serviceClient.Subtract(nums).ToString();
		}
	}
}
