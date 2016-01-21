using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOrigin.Core.Domain
{
    public class Rooms
    {
        public int id {get; set;}
        public int RoomNumber { get; set; }
        public int Beds { get; set; }
        public bool HasTV { get; set; }
    }
}
