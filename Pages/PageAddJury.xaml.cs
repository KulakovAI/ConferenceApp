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
    /// Логика взаимодействия для PageAddJury.xaml
    /// </summary>
    public partial class PageAddJury : Page
    {
        private Jury _currentItem = new Jury();
        public PageAddJury(Jury selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _currentItem = selectedItem;
                Titletxt.Text = "Изменение жюри";
                BtnAdd.Content = "Изменить";
            }
            DataContext = _currentItem;

            CMBCountry.ItemsSource = ConferenceEntities.GetContext().Country.ToList();
            CMBCountry.SelectedValuePath = "IdCountry";
            CMBCountry.DisplayMemberPath = "NameCountry";

            CMBDir.ItemsSource = ConferenceEntities.GetContext().Country.ToList();
            CMBDir.SelectedValuePath = "IdDirictory";
            CMBCountry.DisplayMemberPath = "NameDir";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentItem.Email)) error.AppendLine("Укажите адрес");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentItem.DateBirthday))) error.AppendLine("Укажите дату рождения");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentItem.IdCountry))) error.AppendLine("Укажите название компании");
            if (string.IsNullOrWhiteSpace(_currentItem.Phone)) error.AppendLine("Укажите телефон");
            if (string.IsNullOrWhiteSpace(_currentItem.Password)) error.AppendLine("Укажите пароль");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentItem.IdDirictory))) error.AppendLine("Укажите направление");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentItem.IdJury == 0)
            {
                ConferenceEntities.GetContext().Jury.Add(_currentItem);
                try
                {
                    ConferenceEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new PageJury());
                    MessageBox.Show("Новый жюри успешно добавлен!");
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
                    Classes.ClassFrame.frmObj.Navigate(new PageJury());
                    MessageBox.Show("Жюри успешно изменён!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new PageJury());
        }
    }
}
