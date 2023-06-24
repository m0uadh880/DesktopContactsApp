using System.Windows;
using SQLite;


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
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Classes.Contact>();
                var contacts = conn.Table<Classes.Contact>().ToList();
            }
        }
    }
}
