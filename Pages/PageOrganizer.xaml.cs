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
using ConferenceApp.Classes;

namespace ConferenceApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrganizer.xaml
    /// </summary>
    public partial class PageOrganizer : Page
    {
        int NumberId;
        public PageOrganizer(int id)
        {
            InitializeComponent();
            NumberId = id;
            Organizer organizer = null;
            organizer = ConferenceEntities.GetContext().Organizer.Where(x => x.IdOrganizer.ToString() == id.ToString()).FirstOrDefault();
            var gender = "";
            var time = "";
            if (organizer.Gender == "женский")
                gender = "Ms";
            else
                gender = "Mr";

            DateTime currentTime = DateTime.Now;
            TimeSpan timeOfDay = currentTime.TimeOfDay;
            if (timeOfDay.Hours < 11)
                time = "Доброе утро";
            else if (timeOfDay.Hours < 18)
                time = "Добрый день";
            else
                time = "Добрый вечер";

            TxtOrganizer.Text = gender + " " + organizer.Fio.Split(' ')[1];
            TxtGetting.Text = time;

            Photo.Source = new BitmapImage(new Uri("/Resources/Organizers/" + organizer.Photo, UriKind.RelativeOrAbsolute)); 
        }
        private void BtnEvents_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageEvents());
        }

        private void BtnPers_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePerson());
        }

        private void BtnJury_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageJury());
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageProfile(NumberId));
        }
    }
}
