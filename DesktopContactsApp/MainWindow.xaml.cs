using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Shapes;
using SQLite;
using DesktopContactsApp.Classes;


namespace DesktopContactsApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            ReadDataBase();
        }

        private void AddNewContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDataBase();
        }

        void ReadDataBase()
        {
            List<Contact> contacts;
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList();
            }

            if(contacts != null)
            {
                ContactsListView.ItemsSource = contacts;
            }

        }
    }
}
