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
        public SendEmailButton()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            SendEmail();
        }

        private void SendEmail()
        {
            string login = Application.Current.Resources["login"].ToString();
            string password = Application.Current.Resources["password"].ToString();

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(login, "Bymagka");
            // кому отправляем
            MailAddress to = new MailAddress(login);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "Тест";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(login, password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
