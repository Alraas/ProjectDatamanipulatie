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
    /// Interaction logic for NieuweKlant.xaml
    /// </summary>
    public partial class NieuweKlant : Window
    {
        public NieuweKlant()
        {
            InitializeComponent();
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            
                Customer klant = new Customer();
                klant.lname = txtFamilieNaam.Text;
                klant.fname = txtVoorNaam.Text;
                klant.email = txtEmail.Text;
                klant.phone_number = txtNummer.Text;

                if (klant.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenKlant(klant);
                    if (ok > 0)
                    {
                        MessageBox.Show("Klant is  toegevoegd!");


                        Resetten();
                    }
                    else
                    {
                        MessageBox.Show("Klant is niet toegevoegd!");

                    }
                }
                else
                {
                    MessageBox.Show(klant.Error, "Foutmelding", MessageBoxButton.OK);
                }
            }
           

       
        private void Resetten()
        {
            txtFamilieNaam.Text = "";
            txtVoorNaam.Text = "";
            txtNummer.Text = "";
            txtEmail.Text = "";


        }
    }
}
