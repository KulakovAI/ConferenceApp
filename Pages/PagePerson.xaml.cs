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
    /// Логика взаимодействия для PagePerson.xaml
    /// </summary>
    public partial class PagePerson : Page
    {
        public PagePerson()
        {
            InitializeComponent();
            dtgPers.ItemsSource = ConferenceEntities.GetContext().Person.ToList();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddPerson(null));
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageAddPerson((Person)dtgPers.SelectedItem));
        }

        private void MenuUpdate_Click(object sender, RoutedEventArgs e)
        {
            dtgPers.ItemsSource = ConferenceEntities.GetContext().Person.ToList();
        }

        private void MenuDel_Click(object sender, RoutedEventArgs e)
        {
            var PersForRemoving = dtgPers.SelectedItems.Cast<Person>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {PersForRemoving.Count()} записи?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ConferenceEntities.GetContext().Person.RemoveRange(PersForRemoving);
                    ConferenceEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    dtgPers.ItemsSource = ConferenceEntities.GetContext().Person.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void MenuOrderBy_Click(object sender, RoutedEventArgs e)
        {
            dtgPers.ItemsSource = ConferenceEntities.GetContext().Person.OrderBy(x => x.DateBirthday).ToList();
        }

        private void MenuOrderByDescending_Click(object sender, RoutedEventArgs e)
        {
            dtgPers.ItemsSource = ConferenceEntities.GetContext().Person.OrderByDescending(x => x.DateBirthday).ToList();
        }

    }
}
