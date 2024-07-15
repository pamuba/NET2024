using CalcServiceLibrary;
using CLIENT_1.MathReference;
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
        //private IMathService MathService_basicHttpBinding = null;
        private ICalcService CalcService_basicHttpBinding = null;
        MathServiceClient client = null;
        public MainWindow()
        {
            InitializeComponent();
            client = new MathReference.MathServiceClient();
            //MathService_basicHttpBinding = new ChannelFactory<WCFLibrary.IMathService>
            //    ("MathService_basicHttpBinding").CreateChannel();

            CalcService_basicHttpBinding = new ChannelFactory<CalcServiceLibrary.ICalcService>
               ("CalcService_basicHttpBinding").CreateChannel();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WCFLibrary.MyNumbers obj = new WCFLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = client.Add(obj).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            //obj.Number1 = Convert.ToInt32(firstTB.Text);
            //obj.Number2 = Convert.ToInt32(secondTB.Text);

            //thirdTB.Text = CalcService_basicHttpBinding.Mult(obj).ToString();
        }
    }
}
