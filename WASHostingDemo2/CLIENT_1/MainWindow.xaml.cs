using CLIENT_1.MathServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
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
        //One or request/response messaging
        //private MathServiceClient wsHttpProxy = null;
        //private MathServiceClient netTcpProxy = null;
        //MathServiceReference.MathServiceClient proxy = new MathServiceReference.MathServiceClient();

        //two way/callback messaging
        MathServiceReference.MathServiceClient proxy;
        public MainWindow()
        {
            InitializeComponent();
            var callback = new MathSwerviceCallback();
            var context = new InstanceContext(callback);
            proxy = new MathServiceReference.MathServiceClient(context);
            proxy.SignIn(WindowsIdentity.GetCurrent().Name);


            //wsHttpProxy = new MathServiceClient("WSDualHttpBinding_IMathService");
            //netTcpProxy = new MathServiceClient("NetTcpBinding_IMathService");
            //wsHttpProxy.SignIn(WindowsIdentity.GetCurrent().Name);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = proxy.Add(obj).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyNumbers obj = new MyNumbers();
            obj.Number1 = Convert.ToInt32(firstTB.Text);
            obj.Number2 = Convert.ToInt32(secondTB.Text);

            thirdTB.Text = proxy.Subtract(obj).ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            proxy.SignOut(WindowsIdentity.GetCurrent().Name);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            proxy.StartPrintingLogFiles("Log info has been printed");
        }
    }
}
