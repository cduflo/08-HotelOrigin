using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HotelOrigin.Core;
using HotelOrigin.Core.Domain;

namespace HotelOrigin.Core.Repository
{
    public class RoomRepository
    {
        public static ObservableCollection<HotelOrigin.Core.Domain.Rooms> rooms = new ObservableCollection<Domain.Rooms>();
        public static int idCounter = 0;

        public static Rooms Create(int roomnum, int beds, bool tv)
        {
            Rooms room = new Rooms();
            room.id = idCounter + 1;
            idCounter++;
            room.RoomNumber = roomnum;
            room.Beds = beds;
            room.HasTV = tv;
            rooms.Add(room);
            return new Rooms();

        }

        public static Rooms GetByID(int iD)
        {
            return rooms.FirstOrDefault(c => c.id == iD);
        }
 
        public static ObservableCollection<Rooms> GetAll()
        {
            return rooms;
        }

        public static void Delete(Rooms rm)
        {
            rooms.Remove(rm);
        }

    }
}
