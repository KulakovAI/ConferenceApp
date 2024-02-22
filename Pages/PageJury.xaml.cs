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
    /// Логика взаимодействия для PageJury.xaml
    /// </summary>
    public partial class PageJury : Page
    {
        public PageJury()
        {
            InitializeComponent();
            dtgJury.ItemsSource = ConferenceEntities.GetContext().Jury.ToList();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddJury(null));
        }

        private void MenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            dtgJury.ItemsSource = ConferenceEntities.GetContext().Jury.ToList();
        }

        private void MenuDel_Click(object sender, RoutedEventArgs e)
        {
            var JuryForRemoving = dtgJury.SelectedItems.Cast<Jury>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {JuryForRemoving.Count()} записи?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ConferenceEntities.GetContext().Jury.RemoveRange(JuryForRemoving);
                    ConferenceEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    dtgJury.ItemsSource = ConferenceEntities.GetContext().Jury.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text.Count() != 0) dtgJury.ItemsSource = ConferenceEntities.GetContext().Jury.Where(x => x.Email.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
            if (txbSearch.Text.Count() == 0) dtgJury.ItemsSource = ConferenceEntities.GetContext().Jury.ToList();
        }

        private void MenuEdit_Click_1(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddJury((Jury)dtgJury.SelectedItem));
        }
    }
}
