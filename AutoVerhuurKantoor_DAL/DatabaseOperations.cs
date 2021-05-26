using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace AutoVerhuurKantoor_DAL
{
    public static class DatabaseOperations
    {
        public static List<Rental> OphalenCustomersViaCustomersnaam(string naam)
        {
            using (RentalsEntities entities = new RentalsEntities())
            {
                return entities.Rentals
                    
                    .Include(x => x.Customer)
                    .Where(x => x.Customer.lname.Contains(naam) || x.Customer.fname.Contains(naam))
                    
                    .OrderBy(x => x.Customer. lname)
                    .ThenBy(x => x.Customer. fname)
                    
                    .ToList();
            }

        }
        public static List<Rental> OphalenVerhuursViaVerhuurID(int Verhuur_ID)
        {
            using (RentalsEntities entities = new RentalsEntities())
            {
                return entities.Rentals
                    .Where(x => x.rental_id == Verhuur_ID )
                    .Include(x=> x.Customer)
                    .ToList();
            }

        }
        public static List<Car> OphalenAutos()
        {
            using (RentalsEntities entities = new RentalsEntities())
            {
                return entities.Cars
                    .OrderBy(x => x.car_id)
                    .ToList();
            }
        }
        public static List<Customer> OphalenKlanten()
        {
            using (RentalsEntities entities = new RentalsEntities())
            {
                return entities.Customers
                    .OrderBy(x => x.lname)
                    .ThenBy(x=> x.fname)
                    .ToList();
            }
        }



        public static int VerwijderenAuto(Car car)
        {
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Entry(car).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int VerwijderenVerhuur(Rental verhuur)
        {
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Entry(verhuur).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int AanpasenAuto(Car Auto)
        {
           
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Entry(Auto).State = EntityState.Modified;
                    return entities.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int ToevoegenAuto(Car Auto)
        {
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Cars.Add(Auto);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int ToevoegenVerhuur(Rental verhuur)
        {
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Rentals.Add(verhuur);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int ToevoegenVerhuur_Auto(Agency verhuur)
        {
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Agencies.Add(verhuur);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int ToevoegenKlant(Customer klant)
        {
            try
            {
                using (RentalsEntities entities = new RentalsEntities())
                {
                    entities.Customers.Add(klant);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        // public static List<Agency_Car> OphalenAgencyCarViaCArIDEnAgencyID(int carID, int AgencyID)
        //{
            
            
        //        using (RentalsEntities entities = new RentalsEntities())
        //        {
        //        return entities.Agency_Car

        //            .Include(x => x.Agency)
        //            .Include(x => x.Car)
        //            .Where(x => x.agency_id.Equals(AgencyID) || x.car_id.Equals(carID))
        //            .ToList();

                        

                        
        //        }



            
        //}
        public static Agency_Car OphalenAgencyCarViaCArIDEnAgencyID(int carID, int AgencyID)
        {


            using (RentalsEntities entities = new RentalsEntities())
            {
                return entities.Agency_Car

                    .Include(x => x.Agency)
                    .Include(x => x.Car)
                    .Where(x => x.agency_id.Equals(AgencyID) && x.car_id.Equals(carID)).FirstOrDefault();
                    




            }




        }
        public static Agency_Car OphalenAgencyCarViaCArID(int carID)
        {


            using (RentalsEntities entities = new RentalsEntities())
            {
                return entities.Agency_Car

                    .Include(x => x.Agency)
                    .Include(x => x.Car)
                    .Where(x =>  x.car_id.Equals(carID)).FirstOrDefault();





            }




        }

    }
}
