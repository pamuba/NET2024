using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CLIENT_1
{
    internal class MathSwerviceCallback : MathServiceReference.IMathServiceCallback
    {
        public void NotifyClientWhenPrintingIsDone(string message)
        {
            MessageBox.Show(message);
        }
    }
}
