using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelOrigin.Core;
using HotelOrigin.Core.Domain;
using System.Collections.ObjectModel;

namespace HotelOrigin.Core.Repository
{
    public class ReservationRepository
    {
        public static ObservableCollection<HotelOrigin.Core.Domain.Reservations> reservations = new ObservableCollection<Domain.Reservations>();

        public static int idCounter = 0;

        public static Reservations Create(Customer cus, Rooms rm, DateTime ci, DateTime co, string note)
        {
            Reservations res = new Reservations();
            res.id = idCounter + 1;
            idCounter++;
            res.Customer = cus;
            res.Room = rm;
            res.CheckIn = ci;
            res.CheckOut = co;
            res.Notes = note;
            reservations.Add(res);
            return new Reservations();
    }

        public static Reservations GetByID(int iD)
        {
            return reservations.FirstOrDefault(c => c.id == iD);
        }

        public static ObservableCollection<Reservations> GetAll()
        {
            return reservations;
        }

        public static void Delete(Reservations rm)
        {
            reservations.Remove(rm);
        }

    }
}
