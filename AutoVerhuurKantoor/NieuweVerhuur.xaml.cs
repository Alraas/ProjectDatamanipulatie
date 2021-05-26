using AutoVerhuurKantoor_DAL;
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
using System.Windows.Shapes;

namespace AutoVerhuurKantoor
{
    /// <summary>
    /// Interaction logic for NieuweVerhuur.xaml
    /// </summary>
    public partial class NieuweVerhuur : Window
    {
        public NieuweVerhuur()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbAutos.ItemsSource = DatabaseOperations.OphalenAutos();
            cmbKlanten.ItemsSource = DatabaseOperations.OphalenKlanten();

        }


        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {

            string foutmelding = Valideer("cmbAutos");
            foutmelding += Valideer("cmbKlanten");
            foutmelding += Valideer("startdatum");
            foutmelding += Valideer("einddatum");
            foutmelding += Valideer("prijsPerNacht");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Car auto = cmbAutos.SelectedItem as Car;
                Customer klant = cmbKlanten.SelectedItem as Customer;
                Rental verhuur = new Rental();
                Agency kantoor = cmbKlanten.SelectedItem as Agency;
                Agency_Car kantoor_auto = DatabaseOperations.OphalenAgencyCarViaCArIDEnAgencyID(auto.car_id, kantoor.Agency_id);

               


                
                verhuur.customer_id = klant.customer_id;
                verhuur.agency_car_id = kantoor_auto.agency_car_id;
                verhuur.startDdate = pickStartDatum.SelectedDate;
                verhuur.endDate = pickEindDatum.SelectedDate;

                if (verhuur.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenVerhuur(verhuur);
                    if (ok > 0)
                    {
                        MessageBox.Show("Verhuur is  toegevoegd!");


                        

                    }
                    else
                    {
                        MessageBox.Show("verhuur is niet toegevoegd!");
                    }
                    

                }
                else
                {
                    MessageBox.Show(verhuur.Error);

                }

            }
            else
            {
                MessageBox.Show(foutmelding, "Foutmelding", MessageBoxButton.OK);

            }







        }



       

        private void btnNieuweKlant_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            NieuweKlant nieuweKlant = new NieuweKlant();
            nieuweKlant.ShowDialog();
            cmbKlanten.ItemsSource = DatabaseOperations.OphalenKlanten();
        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NieuweAuto nieuweAuto = new NieuweAuto();
            nieuweAuto.ShowDialog();
            cmbAutos.ItemsSource = DatabaseOperations.OphalenAutos();
        }
        private string Valideer(string columnName)
        {
            if (columnName == "cmbAutos" && cmbAutos.SelectedItem == null)
            {
                return "Selecteer een auto!" + Environment.NewLine;
            }
            if (columnName == "cmbKlanten" && cmbKlanten.SelectedItem == null)
            {
                return "Selecteer een klant!" + Environment.NewLine;
            }
           
            if (columnName == "startdatum" && pickStartDatum.SelectedDate == null)
            {
                return "Selecteer een startdatum!" + Environment.NewLine;
            }
            if (columnName == "einddatum" && pickEindDatum.SelectedDate == null)
            {
                return "Selecteer een einddatum!" + Environment.NewLine;
            }
            


            return "";
        }

        private void cmbAutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cmbAutos.SelectedItem  is Car auto)
            {
                Agency_Car agency_Car = DatabaseOperations.OphalenAgencyCarViaCArID(auto.car_id);

                txtkantoor.Text = agency_Car.ToString();
                txtPrijsPerNacht.Text = agency_Car.pricePerNight.ToString();

               
            }            
        }
    }
}
