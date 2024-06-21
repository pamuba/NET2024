using SQLite;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            //newContactWindow.Show();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }
        void ReadDatabase() {
            
            using (SQLiteConnection con = new SQLiteConnection(App.databasePath)) {
                con.CreateTable<Contact>();
                contacts = con.Table<Contact>().ToList();
            }
            if (contacts != null) {
                //foreach (Contact contact in contacts)
                //{
                //    conatctListView.Items.Add(new ListViewItem() {
                //        Content = contact,
                //    });
                //}

                conatctListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            if (searchBox.Text != "")
            {
                var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchBox.Text.ToLower())).ToList();
                filteredList.Sort();
                conatctListView.ItemsSource = filteredList;
            }
            else {
                conatctListView.ItemsSource = contacts;
            }
        }
    }
}
