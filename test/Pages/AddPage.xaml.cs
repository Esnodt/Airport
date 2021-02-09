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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MainInfo newMaininfo = new MainInfo();
            AdditionalInformation newAdditionalInformation = new AdditionalInformation();
            Airplane newAirplane = new Airplane();
            Route newRoute = new Route();

            newAdditionalInformation.DateAndTimeOfDeparture = (DateTime)tb1.SelectedDate;
            newAdditionalInformation.DateAndTimeOfArrival = (DateTime)tb2.SelectedDate;
            newAdditionalInformation.NumberOfTicketsSold = Convert.ToInt32(tb3.Text);
            newAdditionalInformation.AircraftOccupancy = Convert.ToInt32(tb4.Text);


            newAirplane.NubmerAirplane = Convert.ToInt32(tb5.Text);
            newAirplane.Brand = tb6.Text;
            newAirplane.NumberOfPlaces = Convert.ToInt32(tb7.Text);
            newAirplane.FlightSpeed = Convert.ToInt32(tb8.Text);

            newRoute.NumberRoute = Convert.ToInt32(tb9.Text);
            newRoute.Distance = Convert.ToInt32(tb10.Text);
            newRoute.DeparturePoint = (tb11.Text);
            newRoute.Destination = (tb12.Text);

            newMaininfo.idAdditionalInformation = newAdditionalInformation.ID;
            newMaininfo.idAirplane = newAirplane.ID;
            newMaininfo.idRoute = newRoute.ID;

            dbcontext.db.MainInfo.Add(newMaininfo);
            dbcontext.db.AdditionalInformation.Add(newAdditionalInformation);
            dbcontext.db.Airplane.Add(newAirplane);
            dbcontext.db.Route.Add(newRoute);

            dbcontext.db.SaveChanges();

            MessageBox.Show("Вы добавили данные", "Уведомление");

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
    }
}
