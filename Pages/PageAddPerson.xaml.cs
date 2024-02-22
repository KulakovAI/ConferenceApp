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

namespace ConferenceApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddPerson.xaml
    /// </summary>
    public partial class PageAddPerson : Page

    {
        private Person _currentItem = new Person();
        public PageAddPerson(Person selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _currentItem = selectedItem;
                Titletxt.Text = "Изменение участника";
                BtnAdd.Content = "Изменить";
            }
            DataContext = _currentItem;

            CMBCountry.ItemsSource = ConferenceEntities.GetContext().Country.ToList();
            CMBCountry.SelectedValuePath = "IdCountry";
            CMBCountry.DisplayMemberPath = "NameCountry";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentItem.Fio)) error.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(_currentItem.Email)) error.AppendLine("Укажите адрес");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentItem.DateBirthday))) error.AppendLine("Укажите дату рождения");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentItem.IdCountry))) error.AppendLine("Укажите название компании");
            if (string.IsNullOrWhiteSpace(_currentItem.Password)) error.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(_currentItem.Gender)) error.AppendLine("Укажите пол");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentItem.IdPerson == 0)
            {
                ConferenceEntities.GetContext().Person.Add(_currentItem);
                try
                {
                    ConferenceEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PagePerson());
                    MessageBox.Show("Новый участник успешно добавлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    ConferenceEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PagePerson());
                    MessageBox.Show("Участник успешно изменён!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PagePerson());
        }
    }
}
