using CLIENT_1.MathServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using WCFLibrary;

namespace CLIENT_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MathServiceClient client = null;
        public MainWindow()
        {
            InitializeComponent();
            client = new MathServiceClient("MathService_netTcpBinding");
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = client.Add(obj).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = client.Subtract(obj).ToString();
        }
    }
}
