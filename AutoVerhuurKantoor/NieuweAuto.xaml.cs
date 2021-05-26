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
using AutoVerhuurKantoor_DAL;
using AutoVerhuurKantoor_WPF;

namespace AutoVerhuurKantoor
{
    /// <summary>
    /// Interaction logic for NieuweAuto.xaml
    /// </summary>
    public partial class NieuweAuto : Window
    {
        public NieuweAuto()
        {
            InitializeComponent();
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            
                Car auto = new Car();
                auto.model = txtAutoMerk.Text;
                auto.year = txtAutoJaar.Text;


                if (auto.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenAuto(auto);
                    if (ok > 0)
                    {
                        MessageBox.Show("Auto is  toegevoegd!");
                       
                       
                        Resetten();

                    }
                    else
                    {
                        MessageBox.Show("Auto is niet toegevoegd!");
                    }
                 }
                 else
                 {
                    MessageBox.Show(auto.Error, "Foutmelding", MessageBoxButton.OK);
                 }
        }
           

            


        
        
        private void Resetten()
        {
            txtAutoJaar.Text = "";
            txtAutoMerk.Text = "";
        }
    }
        
}

