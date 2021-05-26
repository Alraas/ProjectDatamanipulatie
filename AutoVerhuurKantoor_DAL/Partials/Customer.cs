using AutoVerhuurKantoor_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerhuurKantoor_DAL
{
   public partial class Customer:BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "fname" && string.IsNullOrWhiteSpace(fname))
                {
                    return "Voornaam is een verplicht veld!";
                }
                if (columnName == "lname" && string.IsNullOrWhiteSpace(lname))
                {
                    return "Achternaam is een verplicht veld!";
                }
                if (columnName == "phone_number" && string.IsNullOrWhiteSpace(phone_number))
                {
                    return "GSM is een verplicht veld!";
                }
                if (columnName == "email" && string.IsNullOrWhiteSpace(email))
                {
                    return "email is een verplicht veld!";
                }
                return "";
            }
        }
        public override string ToString()
        {
            return fname + " " + lname;
        }
    }
}
