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
using System.Windows.Shapes;
using System.Data.Entity;

namespace CinemaWorkplace
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string movieName = tbMovie.Text;

            DateTime selectedDate = (DateTime)dpShowDate.SelectedDate;

            if (selectedDate != null)
            {
                MainWindow.dbContainer.Sessions.Add(new Session { Date = selectedDate,Movie=movieName });
                MainWindow.dbContainer.SaveChanges();
                MainWindow.dbContainer.Sessions.Load();
            }

            

           
        }


    }
}
