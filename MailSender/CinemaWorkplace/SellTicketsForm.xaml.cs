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
    /// Interaction logic for SellTicketsForm.xaml
    /// </summary>
    public partial class SellTicketsForm : Window
    {
        public static readonly DependencyProperty row =
           DependencyProperty.Register("Row", typeof(short), typeof(SellTicketsForm));

        public static readonly DependencyProperty place =
        DependencyProperty.Register("Place", typeof(short), typeof(SellTicketsForm));

        public static readonly DependencyProperty client =
        DependencyProperty.Register("Client", typeof(string), typeof(SellTicketsForm));

        public short Row
        {
            get { return (short)GetValue(row); }
            set { SetValue(row, value); }
        }


        public short Place
        {
            get { return (short)GetValue(place); }
            set { SetValue(place, value); }
        }

        public string Client
        {
            get { return (string)GetValue(client); }
            set { SetValue(client, value); }
        }


        public SellTicketsForm()
        {
            InitializeComponent();
        }

        private void btnCancelTicket_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;

            var moviesList = MainWindow.dbContainer.Sessions.ToList();

            foreach(var movie in moviesList)
            {
                cbMovieShows.Items.Add(movie);
            }
        }

        private void btnSellTicket_Click(object sender, RoutedEventArgs e)
        {
            Session sessionTicket = cbMovieShows.SelectedItem as Session;

            Ticket newTicket = new Ticket
            {
                Client = this.Client,

                Place = this.Place,
                Row = this.Row
            };

            MainWindow.dbContainer.TicketDatabase.Add(new Ticket
            {
                Client=this.Client,
                Session = sessionTicket,
                Place = this.Place,
                Row = this.Row
            });

            MainWindow.dbContainer.SaveChanges();
            MainWindow.dbContainer.TicketDatabase.Load();

            Close();
        }
    }
}
