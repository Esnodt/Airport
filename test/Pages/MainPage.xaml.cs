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
using test.context;

namespace test.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Application.Current.Shutdown();

            }
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TableMain.ItemsSource = dbcontext.db.MainInfo.ToList();
        }

        private void ButtonGoAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }

        private void ButtonGoEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainInfo EditAirport = (MainInfo)TableMain.SelectedItem;
                if (EditAirport != null)
                {
                    NavigationService.Navigate(new EditPage(EditAirport));
                }
                else
                {
                    MessageBox.Show("Вы не выбрали строку которую хотите изменить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }    
            }
            catch
            {

            }
        }

        private void tbsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TableMain.ItemsSource = dbcontext.db.MainInfo.Where(item => item.Airplane.Brand.Contains(tbsearch.Text)
                || item.AdditionalInformation.AircraftOccupancy.ToString().Contains(tbsearch.Text)).ToList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainInfo deleteAirport = (MainInfo)TableMain.SelectedItem;
                if(MessageBox.Show("Вы действительно хотите удалить выбранную строку?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (deleteAirport != null)
                    {
                        dbcontext.db.MainInfo.Remove(deleteAirport);
                        dbcontext.db.SaveChanges();
                        Page_Loaded(sender: null, e: null);
                        MessageBox.Show("Вы удалили строку", "Оповещание", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                        MessageBox.Show("Вы не выбрали строку", "Оповещание");
                }

            }
            catch
            {

            }
        }
    }
}
