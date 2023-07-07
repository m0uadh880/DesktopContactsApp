using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            NameTextBox.Text = contact.Name;
            EmailTextBox.Text = contact.Email;
            PhoneTextBox.Text = contact.Phone;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = NameTextBox.Text;
            contact.Email = EmailTextBox.Text;
            contact.Phone = PhoneTextBox.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Update(contact);
            }
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Contact>();
                    conn.Delete(contact);
                }
                Close();
            }
        }
    }
}
