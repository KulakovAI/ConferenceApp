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
    /// Логика взаимодействия для PageEvents.xaml
    /// </summary>
    public partial class PageEvents : Page
    {
        public PageEvents()
        {
            InitializeComponent();
            dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.ToList();
            CountRows.Text = dtgEvent.Items.Count.ToString();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text.Count() != 0) dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.Where(x => x.NameEvent.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
            if (txbSearch.Text.Count() == 0) dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.ToList();
        }

        private void MenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.Where(x => x.Days > 2).ToList();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.Where(x => x.Days <= 2).ToList();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            dtgEvent.ItemsSource = ConferenceEntities.GetContext().Event.ToList();
        }
    }
}
