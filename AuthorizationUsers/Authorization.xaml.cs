using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ConferenceApp.Classes;
using ConferenceApp.Pages;

namespace ConferenceApp.AuthorizationUsers
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private readonly Timer timer = new Timer();
        private static int failCount = 0;
        public Authorization()
        {
            InitializeComponent();
            timer.Interval = 10_000;
            timer.Elapsed += (e, s) => failCount = 0;
            FillContent();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = TxbLogin.Text.Trim();
            string pass = PsbPassword.Password.Trim();


            if (login.Length == 0)
            {
                TxbLogin.ToolTip = "Поле введено не корректно!";
                TxbLogin.BorderBrush = Brushes.Red;
                failCount++;
            }
            else if (pass.Length < 6)
            {
                PsbPassword.ToolTip = "Поле введено не корректно!";
                PsbPassword.BorderBrush = Brushes.Red;
                failCount++;
            }
            else
            {
                TxbLogin.ToolTip = "";
                TxbLogin.BorderBrush = Brushes.Transparent;
                PsbPassword.ToolTip = "";
                PsbPassword.BorderBrush = Brushes.Transparent;

                Organizer organizer = null;
                Person person = null;
                Moderator moderator = null;
                Jury jury = null;
                using (ConferenceEntities db = new ConferenceEntities())
                {
                    organizer = ConferenceEntities.GetContext().Organizer.Where(x => x.IdOrganizer.ToString() == login && x.Password == pass).FirstOrDefault();
                    person = ConferenceEntities.GetContext().Person.Where(x => x.IdPerson.ToString() == login && x.Password == pass).FirstOrDefault();
                    moderator = ConferenceEntities.GetContext().Moderator.Where(x => x.IdModerator.ToString() == login && x.Password == pass).FirstOrDefault();
                    jury = ConferenceEntities.GetContext().Jury.Where(x => x.IdJury.ToString() == login && x.Password == pass).FirstOrDefault();
                }

                if (TxtCaptcha.Text == TxbCaptcha.Text)
                {
                    if (organizer != null)
                    {
                        MessageBox.Show("Добро пожаловать, " + organizer.Fio + "!", "Успешная авторизация!");
                        WindowOrganizer windowOrganizer = new WindowOrganizer(organizer.IdOrganizer);
                        windowOrganizer.Show();
                        Close();

                    }
                    else if (person != null)
                    {
                        MessageBox.Show("Добро пожаловать, " + person.Fio + "!", "Успешная авторизация!");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else if (moderator != null)
                    {
                        MessageBox.Show("Добро пожаловать, " + moderator.FIO + "!", "Успешная авторизация!");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else if (jury != null)
                    {
                        MessageBox.Show("Добро пожаловать, " + jury.Email + "!", "Успешная авторизация!");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не авторизован!");
                        failCount++;
                        FillContent();
                    }

                }
                else
                {
                    MessageBox.Show("Captcha не пройдена!");
                    failCount++;
                    FillContent();
                }


                if (failCount >= 3)
                {
                    timer.Start();
                    MessageBox.Show("Превышен лимит поыток!");
                    BtnEnter.IsEnabled = true;
                }


            }
        }

        public void FillContent()
        {
            Random random = new Random();
            int num = random.Next(4, 5);
            string captcha = "";
            int totl = 0;
            do
            {
                int chr = random.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    totl++;
                    if (totl == num)
                    {
                        break;
                    }
                }
            }
            while (true);
            TxtCaptcha.Text = captcha;
            TxbCaptcha.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
