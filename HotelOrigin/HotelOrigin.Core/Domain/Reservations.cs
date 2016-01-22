using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOrigin.Core.Domain
{
    public class Reservations
    {
        public int id { get; set; }
        public Rooms Room { get; set; }
        public Customer Customer { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
