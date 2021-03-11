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
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for SendEmailButton.xaml
    /// </summary>
    public partial class SendEmailButton : UserControl
    {
        public static readonly DependencyProperty msgText =
           DependencyProperty.Register("MessageText", typeof(string), typeof(SendEmailButton));

        public static readonly DependencyProperty msgSubject =
        DependencyProperty.Register("Subject", typeof(string), typeof(SendEmailButton));

        public static readonly DependencyProperty msgReciever =
        DependencyProperty.Register("Reciever", typeof(string), typeof(SendEmailButton));

        public string MessageText
        {
            get { return (string)GetValue(msgText); }
            set { SetValue(msgText, value); }
        }


        public string Subject
        {
            get { return (string)GetValue(msgSubject); }
            set { SetValue(msgSubject, value); }
        }

        public string Reciever
        {
            get { return (string)GetValue(msgReciever); }
            set { SetValue(msgReciever, value); }
        }

        public SendEmailButton()
        {
            InitializeComponent();

            
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            
            SendEmail();
        }

        private void SendEmail()
        {
            string login = Application.Current.Resources["login"].ToString();
            string password = Application.Current.Resources["password"].ToString();

            MailAddress from = new MailAddress(login, "Bymagka");
            MailAddress to = new MailAddress(Reciever);
           
            MailMessage m = new MailMessage(from, to);
            
            m.Subject = Subject;
            
            m.Body = MessageText;
                   
            
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            
            smtp.Credentials = new NetworkCredential(login, password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
