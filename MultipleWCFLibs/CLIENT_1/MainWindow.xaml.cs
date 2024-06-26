using CalcServiceLibrary;
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
using WCFLibrary;

namespace CLIENT_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMathService channel1 = null;
        private ICalcService channel2 = null;
        public MainWindow()
        {
            InitializeComponent();
            var endPoint1 = new EndpointAddress("http://localhost:4444/MathService");
            channel1 = ChannelFactory<IMathService>.CreateChannel(new BasicHttpBinding(), endPoint1);

            var endPoint2 = new EndpointAddress("http://localhost:5555/CalcService");
            channel2 = ChannelFactory<ICalcService>.CreateChannel(new BasicHttpBinding(), endPoint2);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WCFLibrary.MyNumbers obj = new WCFLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text =  channel1.Add(obj).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = channel2.Mult(obj).ToString();
        }
    }
}
