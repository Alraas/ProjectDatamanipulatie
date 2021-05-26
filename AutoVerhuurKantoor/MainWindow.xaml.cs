using AutoVerhuurKantoor;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoVerhuurKantoor_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }






        #region Datagrid zoeken en filteren
        private void btnZoekenRental_Click_2(object sender, RoutedEventArgs e)
        {
            string foutmeding = Valideer("VerhuurID");
            if (string.IsNullOrWhiteSpace(foutmeding))
            {
                List<Rental> verhuurs = DatabaseOperations.OphalenVerhuursViaVerhuurID(int.Parse(txtVerhuur_ID.Text));

                if (verhuurs.Count > 0)
                {
                    datagridVerhuurs.ItemsSource = verhuurs;

                }
                else
                {
                    MessageBox.Show("Er zijn geen Verhuurs gevonden voor Verhuur ID " + txtVerhuur_ID.Text);

                }

            }
            else
            {
                MessageBox.Show(foutmeding, "Foutmelding", MessageBoxButton.OK);
            }

        }


        

        private void btnFilterNaam_Click(object sender, RoutedEventArgs e)
        {
            List<Rental> Klanten = DatabaseOperations.OphalenCustomersViaCustomersnaam(txtNaam.Text);
            datagridVerhuurs.ItemsSource = Klanten;
        }
     

        private void btnToonAlles_Click(object sender, RoutedEventArgs e)
        {
            List<Rental> Klanten = DatabaseOperations.OphalenCustomersViaCustomersnaam("");
            datagridVerhuurs.ItemsSource = Klanten;
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbAutos.ItemsSource = DatabaseOperations.OphalenAutos();

        }
        #endregion

        private void btnAutoVerwijderen_Click(object sender, RoutedEventArgs e)
        {

      
            string foutmelding = Valideer("Autos");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Car auto = cmbAutos.SelectedItem as Car;
                int ok = DatabaseOperations.VerwijderenAuto(auto);
                if (ok > 0)
                {
                    cmbAutos.ItemsSource = DatabaseOperations.OphalenAutos();
                    Ressten(); 
                }
                else
                {
                    MessageBox.Show("Auto is niet verwijderd");
                }
            }
            else
            {
                MessageBox.Show(foutmelding, "Foutmelding", MessageBoxButton.OK);
            }

        }
        private void btnVerhuurVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Verhuur");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Rental verhuur = datagridVerhuurs.SelectedItem as Rental;
                int ok = DatabaseOperations.VerwijderenVerhuur(verhuur);
                if (ok > 0)
                {
                    MessageBox.Show("Verhuur is  verwijderd");
                    Ressten();
                }
                else
                {
                    MessageBox.Show("Verhuur is niet verwijderd");
                }
            }
            else
            {
                MessageBox.Show(foutmelding, "Foutmelding", MessageBoxButton.OK);
            }
        }
        private void btnAutoBijwerken_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Autos");
            foutmelding += Valideer("AutoID");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Car Auto = cmbAutos.SelectedItem as Car;
                
                Auto.model = txtAutoModel.Text;
                Auto.year = txtAutoJaar.Text;
                if (Auto.IsGeldig())
                {
                    int ok = DatabaseOperations.AanpasenAuto(Auto);
                    if (ok > 0)
                    {
                        cmbAutos.ItemsSource = DatabaseOperations.OphalenAutos();
                        Ressten();
                    }
                    else
                    {
                        MessageBox.Show("Auto is niet bijgewekt!");
                    }
                }
                else
                {
                    MessageBox.Show(Auto.Error);
                }

            }
            else
            {
                MessageBox.Show(foutmelding, "Foutmelding", MessageBoxButton.OK);
            }
        }


        #region Windows openen
        private void btnAutoTovoegen_Click(object sender, RoutedEventArgs e)
        {
            NieuweAuto nieuweAuto = new NieuweAuto();
            nieuweAuto.ShowDialog();
           cmbAutos.ItemsSource = DatabaseOperations.OphalenAutos();

        }
        private void btnNieuweVerhuur_Click(object sender, RoutedEventArgs e)
        {
            NieuweVerhuur nieuweVerhuur = new NieuweVerhuur();
            nieuweVerhuur.ShowDialog();
            datagridVerhuurs.ItemsSource = DatabaseOperations.OphalenCustomersViaCustomersnaam("");
        }

        #endregion

        private void Ressten()
        {
            txtAutoId.Text = "";
            txtAutoJaar.Text = "";
            txtAutoModel.Text = "";
            txtNaam.Text = "";
            txtVerhuur_ID.Text = "";
            cmbAutos.SelectedIndex = -1;
            datagridVerhuurs.SelectedIndex = -1;
        }

        

        
        private string Valideer(string columnName)
        {
            if (columnName == "Verhuur" && datagridVerhuurs.SelectedItem == null)
            {
                return "Selecteer een Verhuur!" + Environment.NewLine;
            }
            if (columnName == "Autos" && cmbAutos.SelectedItem == null)
            {
                return "Selecteer een auto!" + Environment.NewLine;
            }
            if (columnName == "AutoID" && !int.TryParse(txtAutoId.Text, out int autoID))
            {
                return "AutoID moet een numerieke waarde zijn!" + Environment.NewLine;
            }

            if (columnName == "VerhuurID" && !int.TryParse(txtVerhuur_ID.Text, out int orderID))
            {
                return "Verhuur ID moet een numerieke waarde zijn!" + Environment.NewLine;
            }
            return "";
        }

        private void cmbAutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAutos.SelectedItem is Car auto)
            {
               txtAutoId.Text = auto.car_id.ToString();
               txtAutoJaar.Text = auto.year.ToString();
               txtAutoModel.Text = auto.model.ToString();
            }
        }
    }
}
