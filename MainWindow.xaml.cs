using ConferenceApp.Classes;
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
using ConferenceApp.AuthorizationUsers;

namespace ConferenceApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.frmObj = frmConf;
            frmConf.Navigate(new Pages.PageEvents());
        }

        private void BtnAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            authorization.Show();
            Close();
        }
    }
}
