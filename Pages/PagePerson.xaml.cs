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
            dtgPers.ItemsSource = ConferenceEntities.GetContext().Event.ToList();
        }
    }
}
