using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfAppEmail.Classes;

namespace WpfAppEmail
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        //Contact->ContactControl->MainWindow
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), 
                new PropertyMetadata(new Contact() { Name = "Default Name", Email="deafult@emai.com", Phone="00000000"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            Contact contact = (Contact)e.NewValue;

            if (control != null && contact != null) {
                control.nameTextBox.Text = contact.Name;
                control.emailTextBox.Text = contact.Email;
                control.phoneTextBox.Text = contact.Phone;
            }
        }


        //private Contact contact;

        //public Contact Conatct
        //{
        //    get { return contact; }
        //    set { 
        //        contact = value; 
        //        nameTextBox.Text = contact.Name;
        //        emailTextBox.Text = contact.Email;
        //        phoneTextBox.Text = contact.Phone;
        //    }
        //}

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
