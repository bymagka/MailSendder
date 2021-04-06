using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.Entity;

namespace CinemaWorkplace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        public static CinemaDataBaseContainer dbContainer;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dbContainer = new CinemaDataBaseContainer();

            dbContainer.TicketDatabase.Load();
            dbContainer.Sessions.Load();
            dgSessions.ItemsSource = dbContainer.Sessions.Local;
                   
            
        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
           
        }

        private void btnDeleteSession_Click(object sender, RoutedEventArgs e)
        {
            Session session = dgSessions.SelectedItem as Session;

            if (session != null)
            {
                dbContainer.Sessions.Remove(session);
                dbContainer.SaveChanges();
                dbContainer.Sessions.Load();
                MessageBox.Show("Session successfully removed!");
            }
        }
    }
}
