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
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

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
            
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if(contacts != null)
            {
                ContactsListView.ItemsSource = contacts;
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filtredList = contacts.Where(c => c.Name.ToLower().StartsWith(searchTextBox.Text.ToLower())).ToList();
            ContactsListView.ItemsSource = filtredList;
        }
    }
}
