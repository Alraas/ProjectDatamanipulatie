using AutoVerhuurKantoor_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerhuurKantoor_DAL
{
    public partial class Agency_Car : BasisKlasse
    {
        public override string ToString()
        {
            return Agency.Name;
        }
        public override string this[string columnName]
        {
            get
            {
                

                if (columnName == "pricePerNight" && pricePerNight <= 0)
                {
                    return "VerhuurID moet groter dan 0 zijn!";
                }


                return "";
            }
        }
    }
}
