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
using ConferenceApp.Classes;
using ConferenceApp.Pages;

namespace ConferenceApp.AuthorizationUsers
{
    /// <summary>
    /// Логика взаимодействия для WindowOrganizer.xaml
    /// </summary>
    public partial class WindowOrganizer : Window
    {
        int NumberId;
        public WindowOrganizer(int id)
        {
            InitializeComponent();
            Classes.ClassFrame.frmObj = frmOrg;
            NumberId = id;
            frmOrg.Navigate(new PageOrganizer(id));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            frmOrg.Navigate(new PageOrganizer(NumberId));
        }

        private void frmOrg_ContentRendered(object sender, EventArgs e)
        {
            if (frmOrg.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }
    }
}
