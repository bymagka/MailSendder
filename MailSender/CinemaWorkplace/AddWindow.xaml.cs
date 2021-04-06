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
            int seconds = 0,hour = 0,minute = 0;
            
            if(cboTime.SelectedItem != null)
            {
                string[] timeArray = (cboTime.SelectedItem as ComboBoxItem).Content.ToString().Split(':');
                hour = int.Parse(timeArray[0]);
                minute = int.Parse(timeArray[1]);
            }

            DateTime pickerDate = dpShowDate.SelectedDate.Value;
         
            
            if (pickerDate != null)
            {
                DateTime selectedDate = new DateTime(pickerDate.Year, pickerDate.Month, pickerDate.Day, hour, minute, seconds);

                MainWindow.dbContainer.Sessions.Add(new Session { Date = selectedDate,Movie=movieName });
                MainWindow.dbContainer.SaveChanges();
                MainWindow.dbContainer.Sessions.Load();
            }

            Close();
           
        }


    }
}
