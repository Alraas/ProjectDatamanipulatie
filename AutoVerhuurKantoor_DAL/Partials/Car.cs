using AutoVerhuurKantoor_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerhuurKantoor_DAL
{
    public partial class Car : BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                
                if (columnName == "model" && string.IsNullOrWhiteSpace(model))
                {
                    return "model is een verplicht veld!";
                }
                if (columnName == "year" && string.IsNullOrWhiteSpace(year))
                {
                    return "Jaar is een verplicht veld!";
                }

                return "";
            }
        }
        public override string ToString()
        {
            return car_id + " - " + model + " - "+ year ;
        }

    }
   
}
