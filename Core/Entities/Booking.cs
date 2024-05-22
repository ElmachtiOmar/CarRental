using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Booking : EntityBase
    {
        public string UserId {  get; set; }

        public string OfferId { get; set; }

        public string PickUpLocation { get; set; }

        public string DropOfLocation { get; set; }

       public DateTime PickUpDateTime { get; set; }

        public DateTime DropOfDateTime { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
