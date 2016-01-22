using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using HotelOrigin.Core;
using HotelOrigin.Core.Domain;

namespace HotelOrigin.Core.Repository
{
    public class CustomerRepository
    {
        public static ObservableCollection<HotelOrigin.Core.Domain.Customer> customers = new ObservableCollection<Domain.Customer>();
        public static int idCounter = GetLastID();

        public static Customer Create(string fn, string ln, string em, string tl)
        {
            Customer cust = new Customer();
            cust.id = idCounter+1;
            idCounter++;
            cust.firstName = fn;
            cust.lastName = ln;
            cust.email = em;
            cust.tele = tl;
            customers.Add(cust);
            return new Customer();
        }

        public static Customer GetByID(int iD)
        {
            return customers.FirstOrDefault(c => c.id == iD);
        }
 
        public static int GetLastID()
        {
            List<int> IDS = new List<int>();
            foreach (var x in customers)
            {
                IDS.Add(x.id);
            }
            if (IDS.Count() == 0)
            {
                return 0;
            }
            else
            {
                return (IDS.Max());
            }
        }
 
        public static ObservableCollection<Customer> GetAll()
        {
            return customers;
        }

        public static void Delete(Customer cust)
        {
            customers.Remove(cust);
        }

    }

}
