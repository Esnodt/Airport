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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private MainInfo selecteditems;
        public EditPage()
        {
            InitializeComponent();
        }


        public EditPage(MainInfo selecteditems)
        {
            InitializeComponent();

            this.selecteditems = selecteditems;

            tb1.SelectedDate = selecteditems.AdditionalInformation.DateAndTimeOfDeparture;
            tb2.SelectedDate = selecteditems.AdditionalInformation.DateAndTimeOfArrival;
            tb3.Text = Convert.ToString(selecteditems.AdditionalInformation.NumberOfTicketsSold);
            tb4.Text = Convert.ToString(selecteditems.AdditionalInformation.AircraftOccupancy);

            tb5.Text = Convert.ToString(selecteditems.Airplane.NubmerAirplane);
            tb6.Text = selecteditems.Airplane.Brand;
            tb7.Text = Convert.ToString(selecteditems.Airplane.NumberOfPlaces);
            tb8.Text = Convert.ToString(selecteditems.Airplane.FlightSpeed);

            tb9.Text = Convert.ToString(selecteditems.Route.NumberRoute);
            tb10.Text = Convert.ToString(selecteditems.Route.Distance);
            tb11.Text = selecteditems.Route.DeparturePoint;
            tb12.Text = selecteditems.Route.Destination;
        }


        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            MainInfo Save = dbcontext.db.MainInfo.FirstOrDefault(item => item.ID == selecteditems.ID);

            Save.AdditionalInformation.DateAndTimeOfDeparture = (DateTime)tb1.SelectedDate;
            Save.AdditionalInformation.DateAndTimeOfArrival = (DateTime)tb2.SelectedDate;
            Save.AdditionalInformation.NumberOfTicketsSold = Convert.ToInt32(tb3.Text);
            Save.AdditionalInformation.AircraftOccupancy = Convert.ToInt32(tb4.Text);

            Save.Airplane.NubmerAirplane = Convert.ToInt32(tb5.Text);
            Save.Airplane.Brand = (tb6.Text);
            Save.Airplane.NumberOfPlaces = Convert.ToInt32(tb7.Text);
            Save.Airplane.FlightSpeed = Convert.ToInt32(tb8.Text);

            Save.Route.NumberRoute = Convert.ToInt32(tb9.Text);
            Save.Route.Distance = Convert.ToInt32(tb10.Text);
            Save.Route.DeparturePoint = (tb11.Text);
            Save.Route.Destination = (tb12.Text);

            dbcontext.db.SaveChanges();
            MessageBox.Show("Данные изменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();








        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
            tb9.Text = "";
            tb10.Text = "";
            tb11.Text = "";
            tb12.Text = "";
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
