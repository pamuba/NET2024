using CalcServiceLibrary;
using System;
using System.ServiceModel;
using System.Windows;



namespace CLIENT_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IMathService MathService_basicHttpBinding = null;
        private ICalcService CalcService_basicHttpBinding = null;
        //CalcServiceClient client = null;
        public MainWindow()
        {
            InitializeComponent();
            //client = new CalcReference.CalcServiceClient();
            //MathService_basicHttpBinding = new ChannelFactory<WCFLibrary.IMathService>
            //    ("MathService_basicHttpBinding").CreateChannel();

            CalcService_basicHttpBinding = new ChannelFactory<CalcServiceLibrary.ICalcService>
               ("CalcService_basicHttpBinding").CreateChannel();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            //WCFLibrary.MyNumbers obj = new WCFLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = CalcService_basicHttpBinding.Mult(obj).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            CalcServiceLibrary.MyNumbers obj = new CalcServiceLibrary.MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = CalcService_basicHttpBinding.Div(obj).ToString();
        }
    }
}
