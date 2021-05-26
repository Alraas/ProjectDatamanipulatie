using AutoVerhuurKantoor_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerhuurKantoor_DAL
{
    public partial class Rental : BasisKlasse
    {
        
       

        public override string this[string columnName]
        {
            get
            {
                
                if (columnName == "startDdate" && startDdate.HasValue == false)
                {
                    return "Startdatum moet bepaald  zijn";
                }
                if (columnName == "endDate" && endDate.Value < startDdate)
                {
                    return "Einddatum moet na het startdatum zijn";
                }
                

                return "";
            }
        }
    }
}
